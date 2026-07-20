using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class MatchDetailsDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? MatchType { get; set; }
        public string? Status { get; set; }
        public string? Venue { get; set; }
        public string? Date { get; set; }
        public DateTime? DateTimeGMT { get; set; }

        public List<string> Teams { get; set; } = [];
        public List<TeamInfoDto> TeamInfo { get; set; } = [];
        public List<ScoreDto> Score { get; set; } = [];

        public string? TossWinner { get; set; }
        public string? TossChoice { get; set; }
        public string? MatchWinner { get; set; }

        public List<ScorecardDto> Scorecard { get; set; } = [];

        public bool MatchStarted { get; set; }
        public bool MatchEnded { get; set; }
    }
}
