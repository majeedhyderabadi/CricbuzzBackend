using MatchApi.Domain.Common;
using MatchApi.Domain.Enums;

namespace MatchApi.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Sport Sport { get; set; }
    public string ColorHex { get; set; } = string.Empty;

    public ICollection<Player> Players { get; set; } = new List<Player>();

    public static Team Create(string name, Sport sport, string colorHex)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Team name is required.");
        }

        if (string.IsNullOrWhiteSpace(colorHex))
        {
            throw new InvalidOperationException("Team color is required.");
        }

        return new Team
        {
            Name = name,
            Sport = sport,
            ColorHex = colorHex
        };
    }
}
