using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Fixtures.Common;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Commands.UpdateFixtureScore;

public class UpdateFixtureScoreCommandHandler : IRequestHandler<UpdateFixtureScoreCommand, FixtureDto>
{
    private readonly IFixtureRepository _fixtureRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFixtureScoreCommandHandler(IFixtureRepository fixtureRepository, IUnitOfWork unitOfWork)
    {
        _fixtureRepository = fixtureRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FixtureDto> Handle(UpdateFixtureScoreCommand request, CancellationToken cancellationToken)
    {
        var fixture = await _fixtureRepository.GetByIdAsync(request.FixtureId, cancellationToken)
            ?? throw new InvalidOperationException("Fixture not found.");

        fixture.UpdateScore(request.Side, request.RunsDelta, request.WicketsDelta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new FixtureDto(
            fixture.Id,
            fixture.HomeTeamId,
            fixture.HomeTeam?.Name ?? string.Empty,
            fixture.AwayTeamId,
            fixture.AwayTeam?.Name ?? string.Empty,
            fixture.Sport?.Name ?? string.Empty,
            fixture.ScheduledAtUtc,
            fixture.Status.ToString(),
            fixture.Phase?.ToString(),
            fixture.HomeScore.Runs,
            fixture.HomeScore.Wickets,
            fixture.AwayScore.Runs,
            fixture.AwayScore.Wickets,
            fixture.SportId);
    }
}
