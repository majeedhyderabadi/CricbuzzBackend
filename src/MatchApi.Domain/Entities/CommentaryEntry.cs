using MatchApi.Domain.Common;
using MatchApi.Domain.Enums;

namespace MatchApi.Domain.Entities;

public class CommentaryEntry : BaseEntity
{
    public Guid FixtureId { get; set; }
    public Fixture? Fixture { get; set; }

    public FixtureSide Side { get; set; }

    public Guid? PlayerId { get; set; }
    public Player? Player { get; set; }

    public CommentaryAction Action { get; set; }
    public string? Note { get; set; }

    public static CommentaryEntry Create(Guid fixtureId, FixtureSide side, Guid? playerId, CommentaryAction action, string? note)
    {
        return new CommentaryEntry
        {
            FixtureId = fixtureId,
            Side = side,
            PlayerId = playerId,
            Action = action,
            Note = note
        };
    }
}
