using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public sealed record SearchFixturesQuery(string SearchTerm)
    : IRequest<List<SearchFixturesResponse>>;