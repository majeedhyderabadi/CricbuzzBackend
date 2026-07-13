using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class BattingDto
    {
        public PlayerDto? Batsman { get; set; }

        [JsonPropertyName("dismissal-text")]
        public string? DismissalText { get; set; }

        public int R { get; set; }
        public int B { get; set; }

        [JsonPropertyName("4s")]
        public int Fours { get; set; }

        [JsonPropertyName("6s")]
        public int Sixes { get; set; }

        public double Sr { get; set; }
    }
}
