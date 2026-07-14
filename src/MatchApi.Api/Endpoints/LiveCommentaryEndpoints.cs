using MatchApi.Application.Features.LiveCommentary.Queries.GetMatchCommentary;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class LiveCommentaryEndpoints
{
    public static void MapLiveCommentaryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/matches/{cricbuzzMatchId:int}/commentary",
            async (
                int cricbuzzMatchId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(
                    new GetMatchCommentaryQuery(cricbuzzMatchId),
                    cancellationToken);

                return Results.Ok(result);
            })
            .WithName("GetMatchCommentary")
            .WithTags("Live Commentary");
    }
}