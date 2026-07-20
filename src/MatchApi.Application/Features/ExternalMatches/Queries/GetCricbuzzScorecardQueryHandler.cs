using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries.GetCricbuzzScorecard;

public class GetCricbuzzScorecardQueryHandler
    : IRequestHandler<
        GetCricbuzzScorecardQuery,
        CricbuzzScorecardResponseDto?>
{
    private readonly ICricbuzzService _cricbuzzService;

    public GetCricbuzzScorecardQueryHandler(
        ICricbuzzService cricbuzzService)
    {
        _cricbuzzService = cricbuzzService;
    }

    public async Task<CricbuzzScorecardResponseDto?> Handle(
        GetCricbuzzScorecardQuery request,
        CancellationToken cancellationToken)
    {
        return await _cricbuzzService.GetScorecardAsync(
            request.MatchId,
            cancellationToken);
    }
}