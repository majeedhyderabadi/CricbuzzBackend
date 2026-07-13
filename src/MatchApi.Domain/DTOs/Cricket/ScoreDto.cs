using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class ScoreDto
    {
        public int R { get; set; }
        public int W { get; set; }
        public double O { get; set; }
        public string? Inning { get; set; }
    }
}
