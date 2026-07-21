public sealed class SearchFixturesResponse
{
    public Guid Id { get; set; }

    public Guid HomeTeamId { get; set; }
    public string HomeTeamName { get; set; } = string.Empty;

    public Guid AwayTeamId { get; set; }
    public string AwayTeamName { get; set; } = string.Empty;

    public Guid SportId { get; set; }
    public string Sport { get; set; } = string.Empty;

    public DateTime ScheduledAtUtc { get; set; }

    public string Status { get; set; } = string.Empty;

    public int HomeScore { get; set; }
    public int HomeWickets { get; set; }

    public int AwayScore { get; set; }
    public int AwayWickets { get; set; }
}