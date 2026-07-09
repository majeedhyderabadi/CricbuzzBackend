using FluentValidation;
using MatchApi.Application.Features.Fixtures.Commands.CreateFixture;
using MatchApi.Application.Features.Fixtures.Common;
using MatchApi.Application.Features.Fixtures.Queries.GetLiveFixtures;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class FixtureEndpoints
{
    public static IEndpointRouteBuilder MapFixtureEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fixtures")
            .WithTags("Fixtures");

        group.MapPost("/", CreateFixture)
            .WithName("CreateFixture")
            .WithSummary("Schedules a fixture between two teams")
            .Produces<CreateFixtureResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapGet("/live", GetLiveFixtures)
            .WithName("GetLiveFixtures")
            .WithSummary("Gets all fixtures that are currently live")
            .Produces<IReadOnlyList<FixtureDto>>(StatusCodes.Status200OK);

        return app;
    }

    private static async Task<IResult> GetLiveFixtures(ISender sender, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetLiveFixturesQuery(), cancellationToken);
        return Results.Ok(response);
    }

    private static async Task<IResult> CreateFixture(
        CreateFixtureCommand command,
        ISender sender,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await sender.Send(command, cancellationToken);
            return Results.Created($"/api/fixtures/{response.Id}", response);
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
