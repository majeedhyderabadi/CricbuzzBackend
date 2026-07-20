namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public sealed class SearchFixturesResponse
{
    public Guid Id { get; set; }

    public string Sport { get; set; } = string.Empty;

    public string HomeTeam { get; set; } = string.Empty;

    public string AwayTeam { get; set; } = string.Empty;

    public DateTime ScheduledAtUtc { get; set; }

    public string Status { get; set; } = string.Empty;
}