using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class CurrentMatchesResponse
    {
        public string? ApiKey { get; set; }
        public List<CurrentMatchDto> Data { get; set; } = [];
    }
}
