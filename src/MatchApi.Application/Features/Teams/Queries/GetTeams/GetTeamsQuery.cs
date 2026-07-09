using MediatR;

namespace MatchApi.Application.Features.Teams.Queries.GetTeams;
public record GetTeamsQuery() : IRequest<List<GetTeamsResponse>>;
