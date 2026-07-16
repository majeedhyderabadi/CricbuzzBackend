using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public class SearchFixturesQueryHandler
    : IRequestHandler<SearchFixturesQuery,
        IReadOnlyList<SearchFixturesResponse>>
{
    private readonly IFixtureRepository _fixtureRepository;

    public SearchFixturesQueryHandler(
        IFixtureRepository fixtureRepository)
    {
        _fixtureRepository = fixtureRepository;
    }

    public async Task<IReadOnlyList<SearchFixturesResponse>> Handle(
        SearchFixturesQuery request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            return [];
        }

        var fixtures = await _fixtureRepository.SearchAsync(
            request.SearchTerm,
            cancellationToken);

        return fixtures
            .Select(f => new SearchFixturesResponse(
                f.Id,
                f.HomeTeam.Name,
                f.AwayTeam.Name,
                f.Sport.Name,
                f.ScheduledAtUtc))
            .ToList();
    }
}