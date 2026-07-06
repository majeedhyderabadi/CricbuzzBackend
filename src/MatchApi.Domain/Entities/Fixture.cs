using MatchApi.Domain.Common;
using MatchApi.Domain.Enums;

namespace MatchApi.Domain.Entities;

public class Fixture : BaseEntity
{
    public Guid HomeTeamId { get; set; }
    public Team? HomeTeam { get; set; }

    public Guid AwayTeamId { get; set; }
    public Team? AwayTeam { get; set; }

    public Sport Sport { get; set; }
    public DateTime ScheduledAtUtc { get; set; }
    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

    public int HomeScore { get; set; }
    public int? HomeWickets { get; set; }
    public int AwayScore { get; set; }
    public int? AwayWickets { get; set; }

    public ICollection<CommentaryEntry> CommentaryEntries { get; set; } = new List<CommentaryEntry>();

    public static Fixture Create(Team homeTeam, Team awayTeam, DateTime scheduledAtUtc)
    {
        if (homeTeam.Id == awayTeam.Id)
        {
            throw new InvalidOperationException("A team cannot play against itself.");
        }

        if (homeTeam.Sport != awayTeam.Sport)
        {
            throw new InvalidOperationException("Both teams must play the same sport.");
        }

        return new Fixture
        {
            HomeTeamId = homeTeam.Id,
            AwayTeamId = awayTeam.Id,
            Sport = homeTeam.Sport,
            ScheduledAtUtc = scheduledAtUtc,
            Status = MatchStatus.Scheduled,
            HomeWickets = homeTeam.Sport == Sport.Cricket ? 0 : null,
            AwayWickets = homeTeam.Sport == Sport.Cricket ? 0 : null
        };
    }

    public CommentaryEntry AddCommentary(FixtureSide side, Guid playerId, CommentaryAction action, string? note)
    {
        if (Sport != Sport.Cricket)
        {
            throw new InvalidOperationException("Ball-by-ball commentary is only supported for cricket fixtures.");
        }

        var runs = action switch
        {
            CommentaryAction.Six => 6,
            CommentaryAction.Four => 4,
            CommentaryAction.Single => 1,
            CommentaryAction.Wide => 1,
            CommentaryAction.Wicket => 0,
            _ => 0
        };

        var wickets = action == CommentaryAction.Wicket ? 1 : 0;

        ApplyDelta(side, runs, wickets);

        var entry = CommentaryEntry.Create(Id, side, playerId, action, note);
        CommentaryEntries.Add(entry);
        return entry;
    }

    // Backs the Score Control panel: admin nudges RUNS/WKTS directly (no player attached),
    // and it still leaves a trail in the commentary feed per the "also logs a commentary entry" UX.
    public CommentaryEntry AdjustScore(FixtureSide side, int runsDelta, int wicketsDelta, string? note = null)
    {
        if (wicketsDelta != 0 && Sport != Sport.Cricket)
        {
            throw new InvalidOperationException("Wickets can only be adjusted for cricket fixtures.");
        }

        ApplyDelta(side, runsDelta, wicketsDelta);

        var action = wicketsDelta != 0
            ? CommentaryAction.Wicket
            : runsDelta switch
            {
                6 => CommentaryAction.Six,
                4 => CommentaryAction.Four,
                _ => CommentaryAction.Single
            };

        var entry = CommentaryEntry.Create(Id, side, playerId: null, action, note ?? "Score updated manually");
        CommentaryEntries.Add(entry);
        return entry;
    }

    private void ApplyDelta(FixtureSide side, int runsDelta, int wicketsDelta)
    {
        if (side == FixtureSide.Home)
        {
            HomeScore += runsDelta;
            if (wicketsDelta != 0)
            {
                HomeWickets = (HomeWickets ?? 0) + wicketsDelta;
            }
        }
        else
        {
            AwayScore += runsDelta;
            if (wicketsDelta != 0)
            {
                AwayWickets = (AwayWickets ?? 0) + wicketsDelta;
            }
        }
    }
}
