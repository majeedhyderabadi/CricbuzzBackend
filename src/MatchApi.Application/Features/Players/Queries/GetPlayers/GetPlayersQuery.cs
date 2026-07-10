using MediatR;

namespace MatchApi.Application.Features.Players.Queries.GetPlayers;

public record GetPlayersQuery(Guid TeamId)
    : IRequest<List<GetPlayersResponse>>;
