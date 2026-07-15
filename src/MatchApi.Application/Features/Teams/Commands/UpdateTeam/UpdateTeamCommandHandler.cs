using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MatchApi.Domain.Entities;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler
    : IRequestHandler<UpdateTeamCommand, ResponseResult<bool>>
    {
        private readonly ITeamRepository _repository;

        public UpdateTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<bool>> Handle(
            UpdateTeamCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                Team updatedTeam = new Team
                {
                    Id = request.Id,
                    Name = request.Name,
                    SportId = request.SportId,
                    ColorHex = request.ColorHex
                };
                await _repository.UpdateTeamAsync(updatedTeam, cancellationToken);

                return new ResponseResult<bool> { Success= true, Message = "Team updated successfully."};
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool> { Success = false, Error = new Error { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError.ToString()} };
            }
        }
    }
}
