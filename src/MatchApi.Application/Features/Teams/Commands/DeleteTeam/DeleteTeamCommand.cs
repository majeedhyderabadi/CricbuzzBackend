using MatchApi.Domain.DTOs;
using MediatR;
namespace MatchApi.Application.Features.Teams.Commands.DeleteTeam;
public record DeleteTeamCommand(Guid TeamId) : IRequest<ResponseResult<bool>>;