using MediatR;
namespace MatchApi.Application.Features.Teams.Commands.UpdateTeam;
public record UpdateTeamCommand(
    Guid Id,
    string Name,
    Guid SportId,
    string ColorHex
) : IRequest<bool>;
