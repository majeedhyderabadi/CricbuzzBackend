using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public class SearchFixturesQueryHandler
    : IRequestHandler<SearchFixturesQuery, List<SearchFixturesResponse>>
{
    private readonly IFixtureRepository _fixtureRepository;

    public SearchFixturesQueryHandler(
        IFixtureRepository fixtureRepository)
    {
        _fixtureRepository = fixtureRepository;
    }

    public async Task<List<SearchFixturesResponse>> Handle(
        SearchFixturesQuery request,
        CancellationToken cancellationToken)
    {
        var fixtures = await _fixtureRepository.SearchAsync(
            request.SearchTerm,
            cancellationToken);

        return fixtures.Select(f => new SearchFixturesResponse
        {
            Id = f.Id,
            Sport = f.Sport.Name,
            HomeTeam = f.HomeTeam.Name,
            AwayTeam = f.AwayTeam.Name,
            ScheduledAtUtc = f.ScheduledAtUtc,
            Status = f.Status.ToString()
        }).ToList();
    }
}