using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries.SearchMatches;

public class SearchMatchesQueryHandler
    : IRequestHandler<SearchMatchesQuery, CricbuzzMatchListDto>
{
    private readonly ICricbuzzService _cricbuzzService;

    public SearchMatchesQueryHandler(ICricbuzzService cricbuzzService)
    {
        _cricbuzzService = cricbuzzService;
    }

    public async Task<CricbuzzMatchListDto> Handle(
        SearchMatchesQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _cricbuzzService.GetMatchesAsync();

        if (response == null)
        {
            return new CricbuzzMatchListDto();
        }

        if (string.IsNullOrWhiteSpace(request.SearchText))
        {
            return response;
        }

        response.Matches = response.Matches
            .Where(match =>
                (match.Match.MatchInfo.Team1.TeamName?.Contains(
                    request.SearchText,
                    StringComparison.OrdinalIgnoreCase) ?? false)
                ||
                (match.Match.MatchInfo.Team2.TeamName?.Contains(
                    request.SearchText,
                    StringComparison.OrdinalIgnoreCase) ?? false)
                ||
                (match.Match.MatchInfo.SeriesName?.Contains(
                    request.SearchText,
                    StringComparison.OrdinalIgnoreCase) ?? false)
                ||
                (match.Match.MatchInfo.MatchDesc?.Contains(
                    request.SearchText,
                    StringComparison.OrdinalIgnoreCase) ?? false)
            )
            .ToList();

        return response;
    }
}