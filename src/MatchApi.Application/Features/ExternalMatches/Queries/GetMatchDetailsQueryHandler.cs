using MediatR;
using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;

namespace MatchApi.Application.Features.ExternalMatches.Queries.GetMatchDetails;

public class GetMatchDetailsQueryHandler
    : IRequestHandler<GetMatchDetailsQuery, MatchDetailsResponse>
{
    private readonly ICricApiService _cricApiService;

    public GetMatchDetailsQueryHandler(ICricApiService cricApiService)
    {
        _cricApiService = cricApiService;
    }

    public async Task<MatchDetailsResponse> Handle(
        GetMatchDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _cricApiService.GetMatchDetailsAsync(
            request.MatchId,
            cancellationToken);
    }
}