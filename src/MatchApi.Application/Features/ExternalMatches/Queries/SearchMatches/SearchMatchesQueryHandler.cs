using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries.SearchMatches;

public class SearchMatchesQueryHandler
    : IRequestHandler<SearchMatchesQuery, CurrentMatchesResponse>
{
    private readonly ICricApiService _cricApiService;

    public SearchMatchesQueryHandler(ICricApiService cricApiService)
    {
        _cricApiService = cricApiService;
    }

    public async Task<CurrentMatchesResponse> Handle(
        SearchMatchesQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _cricApiService.GetCurrentMatchesAsync(
            cancellationToken: cancellationToken);

        if (string.IsNullOrWhiteSpace(request.SearchText))
        {
            return response;
        }

        response.Data = response.Data
            .Where(match =>
                (!string.IsNullOrWhiteSpace(match.Name) &&
                 match.Name.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase))
                ||
                match.Teams.Any(team =>
                    team.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        return response;
    }
}