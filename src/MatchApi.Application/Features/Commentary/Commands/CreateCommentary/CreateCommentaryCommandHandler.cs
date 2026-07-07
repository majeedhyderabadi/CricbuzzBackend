using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Commentary.Common;
using MatchApi.Domain.Enums;
using MediatR;

namespace MatchApi.Application.Features.Commentary.Commands.CreateCommentary;

public class CreateCommentaryCommandHandler : IRequestHandler<CreateCommentaryCommand, CommentaryDto>
{
    private readonly IFixtureRepository _fixtureRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommentaryBroadcaster _broadcaster;

    public CreateCommentaryCommandHandler(
        IFixtureRepository fixtureRepository,
        IPlayerRepository playerRepository,
        IUnitOfWork unitOfWork,
        ICommentaryBroadcaster broadcaster)
    {
        _fixtureRepository = fixtureRepository;
        _playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
        _broadcaster = broadcaster;
    }

    public async Task<CommentaryDto> Handle(CreateCommentaryCommand request, CancellationToken cancellationToken)
    {
        var fixture = await _fixtureRepository.GetByIdAsync(request.FixtureId, cancellationToken)
            ?? throw new InvalidOperationException("Fixture not found.");

        if (fixture.Status != MatchStatus.Live)
        {
            throw new InvalidOperationException("Commentary can only be added to a live fixture.");
        }

        var player = await _playerRepository.GetByIdAsync(request.PlayerId, cancellationToken)
            ?? throw new InvalidOperationException("Player not found.");

        var expectedTeamId = request.Side == FixtureSide.Home ? fixture.HomeTeamId : fixture.AwayTeamId;
        if (player.TeamId != expectedTeamId)
        {
            throw new InvalidOperationException("Player does not belong to the team on the selected side.");
        }

        var entry = fixture.AddCommentary(request.Side, request.PlayerId, request.Action, request.Note);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = new CommentaryDto(
            entry.Id,
            fixture.Id,
            entry.Side.ToString(),
            player.Id,
            player.Name,
            entry.Action.ToString(),
            entry.Note,
            entry.CreatedAtUtc,
            fixture.HomeScore,
            fixture.HomeWickets,
            fixture.AwayScore,
            fixture.AwayWickets);

        await _broadcaster.BroadcastAsync(dto, cancellationToken);

        return dto;
    }
}
