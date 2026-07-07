using FluentValidation;
using MatchApi.Application.Features.Commentary.Commands.CreateCommentary;
using MatchApi.Application.Features.Commentary.Common;
using MatchApi.Domain.Enums;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class CommentaryEndpoints
{
    public static IEndpointRouteBuilder MapCommentaryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fixtures/{fixtureId:guid}/commentary")
            .WithTags("Commentary");

        group.MapPost("/", CreateCommentary)
            .WithName("CreateCommentary")
            .WithSummary("Adds a ball-by-ball commentary entry to a live fixture and broadcasts it in real time via SignalR")
            .Produces<CommentaryDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        return app;
    }

    private static async Task<IResult> CreateCommentary(
        Guid fixtureId,
        CreateCommentaryRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new CreateCommentaryCommand(
                fixtureId,
                request.Side,
                request.PlayerId,
                request.Action,
                request.Note);

            var response = await sender.Send(command, cancellationToken);
            return Results.Created($"/api/fixtures/{fixtureId}/commentary/{response.Id}", response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            return Results.ValidationProblem(errors);
        }
        catch (InvalidOperationException ex)
        {
            return Results.Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}

public record CreateCommentaryRequest(FixtureSide Side, Guid PlayerId, CommentaryAction Action, string? Note);
