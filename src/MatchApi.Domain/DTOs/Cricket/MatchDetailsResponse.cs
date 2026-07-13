using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Cricket
{
    public class MatchDetailsResponse
    {
        public MatchDetailsDto? Data { get; set; }
        public string? Status { get; set; }
    }
}
