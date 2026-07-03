using FluentValidation;
using MatchApi.Application.Features.Matches.Commands.CreateMatch;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class MatchEndpoints
{
    public static IEndpointRouteBuilder MapMatchEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/matches")
            .WithTags("Matches");

        group.MapPost("/", CreateMatch)
            .WithName("CreateMatch")
            .WithSummary("Creates a new match")
            .Produces<CreateMatchResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        return app;
    }

    private static async Task<IResult> CreateMatch(
        CreateMatchCommand command,
        ISender sender,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await sender.Send(command, cancellationToken);
            // NOTE: replace with Results.CreatedAtRoute once a GetMatchById endpoint exists
            return Results.Created($"/api/matches/{response.Id}", response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            return Results.ValidationProblem(errors);
        }
    }
}
