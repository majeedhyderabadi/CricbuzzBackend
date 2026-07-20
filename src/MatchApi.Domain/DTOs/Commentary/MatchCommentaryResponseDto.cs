using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Domain.DTOs.Commentary
{
    public class MatchCommentaryResponseDto
    {
        public int MatchId { get; set; }

        public List<CommentaryInningsDto> Innings { get; set; } = [];
    }
}
