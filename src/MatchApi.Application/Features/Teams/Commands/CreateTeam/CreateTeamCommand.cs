using MediatR;

namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;

public record CreateTeamCommand(
    string Name,
    Guid SportId,
    string ColorHex) : IRequest<CreateTeamResponse>;
