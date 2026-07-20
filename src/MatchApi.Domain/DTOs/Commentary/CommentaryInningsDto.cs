


namespace MatchApi.Domain.DTOs.Commentary
{
    public class CommentaryInningsDto
    {
        public int InningsId { get; set; }

        public List<CommentaryDto> Commentary { get; set; } = [];
    }
}