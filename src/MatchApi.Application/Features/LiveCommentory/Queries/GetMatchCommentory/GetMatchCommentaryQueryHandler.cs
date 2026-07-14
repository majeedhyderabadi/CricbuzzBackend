using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Commentary;
using MediatR;

namespace MatchApi.Application.Features.LiveCommentary.Queries.GetMatchCommentary;

public class GetMatchCommentaryQueryHandler
    : IRequestHandler<GetMatchCommentaryQuery, MatchCommentaryResponseDto>
{
    private readonly ICricbuzzCommentaryService _commentaryService;

    public GetMatchCommentaryQueryHandler(
        ICricbuzzCommentaryService commentaryService)
    {
        _commentaryService = commentaryService;
    }

    public async Task<MatchCommentaryResponseDto> Handle(
        GetMatchCommentaryQuery request,
        CancellationToken cancellationToken)
    {
        return await _commentaryService.GetCommentaryAsync(
            request.CricbuzzMatchId,
            cancellationToken);
    }
}