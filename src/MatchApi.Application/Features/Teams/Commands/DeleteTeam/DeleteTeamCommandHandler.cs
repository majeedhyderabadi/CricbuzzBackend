using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, ResponseResult<bool>>
    {
        private readonly ITeamRepository _repository;

        public DeleteTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<bool>> Handle(
            DeleteTeamCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var team = await _repository.GetByIdAsync(request.TeamId, cancellationToken);
                if(team == null)
                    return new ResponseResult<bool> { Success = false, Message = "Team does not exist." };

                await _repository.DeleteTeamAsync(request.TeamId, cancellationToken);
                return new ResponseResult<bool> { Success = true, Message = "Team deleted successfully." };
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool> { Success = false, Error = new Error { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError.ToString() } };
            }
        }
    }
}
