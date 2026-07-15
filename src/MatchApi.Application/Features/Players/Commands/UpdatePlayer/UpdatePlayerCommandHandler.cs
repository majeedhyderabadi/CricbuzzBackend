using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MatchApi.Domain.Entities;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandHandler
    : IRequestHandler<UpdatePlayerCommand, ResponseResult<bool>>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<bool>> Handle(
            UpdatePlayerCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                Player player = new Player
                {
                    Id = request.PlayerId,
                    TeamId = request.TeamId,
                    Name = request.PlayerName,
                    SportRoleId = request.SportRoleId
                };
                await _repository.UpdatePlayerAsync(player, cancellationToken);

                return new ResponseResult<bool> { Success = true, Message = "Player updated successfully." };
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool> { Success = false, Error = new Error { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError.ToString() } };
            }
        }
    }
}
