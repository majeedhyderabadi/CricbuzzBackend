using MatchApi.Application.Features.Fixtures.Common;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.GetLiveFixtures;

public record GetLiveFixturesQuery : IRequest<IReadOnlyList<FixtureDto>>;
