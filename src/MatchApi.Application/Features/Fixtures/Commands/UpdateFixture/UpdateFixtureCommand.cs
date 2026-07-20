using MatchApi.Application.Features.Fixtures.Common;
using MatchApi.Domain.Enums;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Commands.UpdateFixture;

public record UpdateFixtureCommand(Guid FixtureId, MatchStatus? Status, MatchPhase? Phase) : IRequest<FixtureDto>;
