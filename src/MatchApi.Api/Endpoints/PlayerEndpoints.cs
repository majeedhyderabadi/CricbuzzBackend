using MatchApi.Application.Features.Players.Commands.AddPlayers;
using MatchApi.Application.Features.Players.Queries.GetPlayers;
using MediatR;

namespace MatchApi.Api.Endpoints
{
    public static class PlayerEndpoints
    {
        public static IEndpointRouteBuilder MapPlayerEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/players")
                .WithTags("Players");

            group.MapPost("/", AddPlayer)
                .WithName("AddPlayer")
                .WithSummary("Add player to a team")
                .Produces<AddPlayerResponse>(StatusCodes.Status201Created)
                .ProducesValidationProblem()
                .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapGet("/team/{teamId:guid}", GetPlayers)
        .WithName("GetPlayers")
        .WithSummary("Get players by team")
        .Produces<List<GetPlayersResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

            return app;
        }
        private static async Task<IResult> GetPlayers(
            Guid teamId,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(
                new GetPlayersQuery(teamId),
                cancellationToken);

            return Results.Ok(response);
        }

        private static async Task<IResult> AddPlayer(
            AddPlayerCommand command,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(command, cancellationToken);

            return Results.Created(
                $"/api/players/{response.Id}",
                response);
        }
    }
}
