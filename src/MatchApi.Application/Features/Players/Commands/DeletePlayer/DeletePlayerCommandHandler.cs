using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.Players.Commands.DeletePlayer;

public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, ResponseResult<bool>>
{
    private readonly IPlayerRepository _repository;

    public DeletePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _repository = playerRepository;
    }

    public async Task<ResponseResult<bool>> Handle(
        DeletePlayerCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var player = await _repository.GetByIdAsync(request.PlayerId, cancellationToken);
            if (player == null)
                return new ResponseResult<bool> { Success = false, Message = "Player does not exist." };

            await _repository.DeletePlayerAsync(request.PlayerId, cancellationToken);
            return new ResponseResult<bool> { Success = true, Message = "Player deleted successfully." };
        }
        catch (Exception ex)
        {
            return new ResponseResult<bool> { Success = false, Error = new Error { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError.ToString() } };
        }
    }

}
