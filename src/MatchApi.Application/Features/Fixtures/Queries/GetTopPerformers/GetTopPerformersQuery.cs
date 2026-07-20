using MatchApi.Application.Features.Fixtures.Common;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.GetTopPerformers;

public record GetTopPerformersQuery(Guid FixtureId) : IRequest<IReadOnlyList<TopPerformerDto>>;
