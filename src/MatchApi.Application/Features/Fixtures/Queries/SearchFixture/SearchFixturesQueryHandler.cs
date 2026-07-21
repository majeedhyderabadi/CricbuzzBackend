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

            HomeTeamId = f.HomeTeamId,
            HomeTeamName = f.HomeTeam.Name,

            AwayTeamId = f.AwayTeamId,
            AwayTeamName = f.AwayTeam.Name,

            SportId = f.SportId,
            Sport = f.Sport.Name,

            ScheduledAtUtc = f.ScheduledAtUtc,
            Status = f.Status.ToString(),

            HomeScore = f.HomeScore.Runs,
            HomeWickets = f.HomeScore.Wickets ?? 0,

            AwayScore = f.AwayScore.Runs,
            AwayWickets = f.AwayScore.Wickets ?? 0,
        }).ToList();
    }
}