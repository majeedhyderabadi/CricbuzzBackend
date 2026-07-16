using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.SearchFixtures;

public record SearchFixturesQuery(string SearchTerm)
    : IRequest<IReadOnlyList<SearchFixturesResponse>>;