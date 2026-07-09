namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;
public record CreateTeamResponse(
    Guid Id,
    string Name,
    string Sport,
    string ColorHex);
