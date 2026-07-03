using MatchApi.Domain.Common;
using MatchApi.Domain.Enums;

namespace MatchApi.Domain.Entities;

public class Match : BaseEntity
{
    public string HomeTeam { get; set; } = string.Empty;
    public string AwayTeam { get; set; } = string.Empty;
    public DateTime MatchDateUtc { get; set; }
    public string Venue { get; set; } = string.Empty;
    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

    // Factory method keeps entity creation rules inside the domain layer
    public static Match Create(string homeTeam, string awayTeam, DateTime matchDateUtc, string venue)
    {
        if (string.Equals(homeTeam, awayTeam, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Home team and away team cannot be the same.");
        }

        return new Match
        {
            HomeTeam = homeTeam,
            AwayTeam = awayTeam,
            MatchDateUtc = matchDateUtc,
            Venue = venue,
            Status = MatchStatus.Scheduled
        };
    }
}
