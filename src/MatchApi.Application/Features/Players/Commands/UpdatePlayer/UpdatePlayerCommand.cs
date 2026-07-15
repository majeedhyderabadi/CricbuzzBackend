using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.UpdatePlayer;
public record UpdatePlayerCommand(
    Guid PlayerId,
    string PlayerName,
    Guid TeamId,
    Guid SportRoleId
) : IRequest<ResponseResult<bool>>;
