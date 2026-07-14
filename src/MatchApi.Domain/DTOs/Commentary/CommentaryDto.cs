

namespace MatchApi.Domain.DTOs.Commentary
{
    public class CommentaryDto
    {
        public double? OverNumber { get; set; }
        public int BallNumber { get; set; }
        public int InningsId { get; set; }

        public string? Commentary { get; set; }
        public string? Event { get; set; }
        public string? BattingTeam { get; set; }

        public int Score { get; set; }

        public string? BatsmanName { get; set; }
        public string? BowlerName { get; set; }

        public long Timestamp { get; set; }
    }
}