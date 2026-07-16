namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public record SearchFixturesResponse(
    Guid FixtureId,
    string HomeTeam,
    string AwayTeam,
    string Sport,
    DateTime ScheduledAtUtc
);