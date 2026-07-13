using MatchApi.Application.Features.ExternalMatches.Queries;
using MatchApi.Application.Features.ExternalMatches.Queries.GetMatchDetails;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class CurrentMatchesEndpoints
{
    public static IEndpointRouteBuilder MapCurrentMatchesEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/matches");

        group.MapGet("/current", async (
            int offset,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(
                new GetCurrentMatchesQuery(offset),
                cancellationToken);

            return Results.Ok(result);
        });

        group.MapGet("/{matchId}", async (
            string matchId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(
                new GetMatchDetailsQuery(matchId),
                cancellationToken);

            return Results.Ok(result);
        });

        return app;

    }
}