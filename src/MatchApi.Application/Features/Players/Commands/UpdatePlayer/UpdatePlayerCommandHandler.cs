using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandHandler
    : IRequestHandler<UpdatePlayerCommand, bool>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            UpdatePlayerCommand request,
            CancellationToken cancellationToken)
        {
            Player player = new Player
            {
                Id = request.PlayerId,
                TeamId = request.TeamId,
                Name = request.PlayerName,
                SportRoleId = request.SportRoleId
            };
            await _repository.UpdatePlayerAsync(player, cancellationToken);

            return true;
        }
    }
}
