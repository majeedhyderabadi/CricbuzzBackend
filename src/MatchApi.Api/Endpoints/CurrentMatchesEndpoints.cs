using MatchApi.Application.Features.ExternalMatches.Queries;
using MatchApi.Application.Features.ExternalMatches.Queries;
using MatchApi.Application.Features.ExternalMatches.Queries.GetCricbuzzScorecard;
using MatchApi.Application.Features.ExternalMatches.Queries.GetMatchDetails;
using MatchApi.Application.Features.ExternalMatches.Queries.SearchMatches;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class CurrentMatchesEndpoints
{
    public static IEndpointRouteBuilder MapCurrentMatchesEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/matches");

        // Existing CricData - Current Matches
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

        // Existing CricData - Match Details
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

        // Cricbuzz - Current Matches
        group.MapGet("/cricbuzz/current", async (
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(
                new GetCricbuzzMatchesQuery(),
                cancellationToken);

            return Results.Ok(result);
        });

        group.MapGet("/cricbuzz/{matchId}/info", async (
    long matchId,
    ISender sender,
    CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(
                new GetCricbuzzMatchInfoQuery(matchId),
                cancellationToken);

            return Results.Ok(result);
        });

        group.MapGet(
    "/cricbuzz/{matchId:long}/scorecard",
    async (
        long matchId,
        ISender sender,
        CancellationToken cancellationToken) =>
    {
        var result = await sender.Send(
            new GetCricbuzzScorecardQuery(matchId),
            cancellationToken);

        return result is null
            ? Results.NotFound()
            : Results.Ok(result);
    });



        group.MapGet("/search", async (
    string searchText,
    ISender sender,
    CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(
                new SearchMatchesQuery(searchText),
                cancellationToken);

            return Results.Ok(result);
        });

        return app;
    }
}