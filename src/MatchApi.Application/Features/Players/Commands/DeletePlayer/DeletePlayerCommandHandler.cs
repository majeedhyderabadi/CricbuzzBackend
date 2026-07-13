using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.DeletePlayer;

public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
{
    private readonly IPlayerRepository _playerRepository;

    public DeletePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<bool> Handle(
        DeletePlayerCommand request,
        CancellationToken cancellationToken)
    {
      await _playerRepository.DeletePlayerAsync(request.PlayerId, cancellationToken);
        return true;
    }

}
