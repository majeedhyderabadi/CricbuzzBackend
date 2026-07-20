using System.Text.Json.Serialization;

namespace MatchApi.Domain.DTOs.Commentary
{
    public class CricbuzzCommentaryResponse
    {
        [JsonPropertyName("matchId")]
        public int MatchId { get; set; }

        [JsonPropertyName("commentary")]
        public List<CricbuzzCommentaryInnings> Commentary { get; set; } = [];
    }

    public class CricbuzzCommentaryInnings
    {
        [JsonPropertyName("inningsId")]
        public int InningsId { get; set; }

        [JsonPropertyName("commentaryList")]
        public List<CricbuzzCommentaryItem> CommentaryList { get; set; } = [];
    }

    public class CricbuzzCommentaryItem
    {
        [JsonPropertyName("commText")]
        public string? CommText { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("ballNbr")]
        public int BallNbr { get; set; }

        [JsonPropertyName("overNumber")]
        public double? OverNumber { get; set; }

        [JsonPropertyName("inningsId")]
        public int InningsId { get; set; }

        [JsonPropertyName("event")]
        public string? Event { get; set; }

        [JsonPropertyName("batTeamName")]
        public string? BatTeamName { get; set; }

        [JsonPropertyName("batTeamScore")]
        public int BatTeamScore { get; set; }

        [JsonPropertyName("batsmanStriker")]
        public CricbuzzBatsman? BatsmanStriker { get; set; }

        [JsonPropertyName("bowlerStriker")]
        public CricbuzzBowler? BowlerStriker { get; set; }
    }

    public class CricbuzzBatsman
    {
        [JsonPropertyName("batId")]
        public int BatId { get; set; }

        [JsonPropertyName("batName")]
        public string? BatName { get; set; }

        [JsonPropertyName("batRuns")]
        public int BatRuns { get; set; }

        [JsonPropertyName("batBalls")]
        public int BatBalls { get; set; }

        [JsonPropertyName("batFours")]
        public int BatFours { get; set; }

        [JsonPropertyName("batSixes")]
        public int BatSixes { get; set; }

        [JsonPropertyName("batStrikeRate")]
        public double BatStrikeRate { get; set; }
    }

    public class CricbuzzBowler
    {
        [JsonPropertyName("bowlId")]
        public int BowlId { get; set; }

        [JsonPropertyName("bowlName")]
        public string? BowlName { get; set; }

        [JsonPropertyName("bowlOvs")]
        public double BowlOvs { get; set; }

        [JsonPropertyName("bowlRuns")]
        public int BowlRuns { get; set; }

        [JsonPropertyName("bowlWkts")]
        public int BowlWkts { get; set; }

        [JsonPropertyName("bowlEcon")]
        public double BowlEcon { get; set; }
    }
}