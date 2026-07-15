using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.DeletePlayer;

public record DeletePlayerCommand(Guid PlayerId) : IRequest<ResponseResult<bool>>;