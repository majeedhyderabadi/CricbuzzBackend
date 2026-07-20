using MatchApi.Domain.DTOs.Commentary;

namespace MatchApi.Application.Common.Interfaces;

public interface ICricbuzzCommentaryService
{
    Task<MatchCommentaryResponseDto> GetCommentaryAsync(
        int cricbuzzMatchId,
        CancellationToken cancellationToken = default);
}