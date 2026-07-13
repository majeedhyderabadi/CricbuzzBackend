namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;
public record CreateTeamResponse(
    Guid Id,
    string Name,
    Guid SportId,
    string ColorHex);
