namespace MatchApi.Application.Features.Matches.Commands.CreateMatch;

public record CreateMatchResponse(
    Guid Id,
    string HomeTeam,
    string AwayTeam,
    DateTime MatchDateUtc,
    string Venue,
    string Status);
