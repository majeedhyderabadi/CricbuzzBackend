namespace MatchApi.Application.Features.Fixtures.Commands.CreateFixture;

public record CreateFixtureResponse(
    Guid Id,
    Guid HomeTeamId,
    string HomeTeamName,
    Guid AwayTeamId,
    string AwayTeamName,
    Guid SportId,
    DateTime ScheduledAtUtc,
    string Status);
