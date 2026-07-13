using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class ScorecardDto
    {
        public List<BattingDto> Batting { get; set; } = [];
        public List<BowlingDto> Bowling { get; set; } = [];
        public ExtrasDto? Extras { get; set; }
        public string? Inning { get; set; }
    }
}
