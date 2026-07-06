using MatchApi.Domain.Common;

namespace MatchApi.Domain.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public Guid TeamId { get; set; }
    public Team? Team { get; set; }

    public static Player Create(string name, string role, Guid teamId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Player name is required.");
        }

        return new Player
        {
            Name = name,
            Role = role,
            TeamId = teamId
        };
    }
}
