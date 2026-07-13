using MatchApi.Domain.Common;

namespace MatchApi.Domain.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid TeamId { get; set; }

    public Team Team { get; set; } = null!;

    public Guid SportRoleId { get; set; }

    public SportRole SportRole { get; set; } = null!;

    public static Player Create(
        string name,
        Guid teamId,
        Guid sportRoleId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Player name is required.");

        if (teamId == Guid.Empty)
            throw new InvalidOperationException("Team is required.");

        if (sportRoleId == Guid.Empty)
            throw new InvalidOperationException("Sport role is required.");

        return new Player
        {
            Name = name,
            TeamId = teamId,
            SportRoleId = sportRoleId
        };
    }
}