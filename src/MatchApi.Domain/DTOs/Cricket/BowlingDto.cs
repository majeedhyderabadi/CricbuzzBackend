using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class BowlingDto
    {
        public PlayerDto? Bowler { get; set; }
        public double O { get; set; }
        public int M { get; set; }
        public int R { get; set; }
        public int W { get; set; }
        public int Nb { get; set; }
        public int Wd { get; set; }
        public double Eco { get; set; }
    }
}
