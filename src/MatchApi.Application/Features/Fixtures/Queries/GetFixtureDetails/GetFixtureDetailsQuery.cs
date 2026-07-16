using MatchApi.Application.Features.Fixtures.Common;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.GetFixtureDetails;

public record GetFixtureDetailsQuery(Guid FixtureId) : IRequest<FixtureDetailsDto>;
