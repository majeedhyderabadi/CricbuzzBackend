using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries;

public class GetCurrentMatchesQueryHandler
    : IRequestHandler<GetCurrentMatchesQuery, CurrentMatchesResponse>
{
    private readonly ICricApiService _cricApiService;

    public GetCurrentMatchesQueryHandler(ICricApiService cricApiService)
    {
        _cricApiService = cricApiService;
    }

    public async Task<CurrentMatchesResponse> Handle(
        GetCurrentMatchesQuery request,
        CancellationToken cancellationToken)
    {
        return await _cricApiService.GetCurrentMatchesAsync(
            request.Offset,
            cancellationToken);
    }
}