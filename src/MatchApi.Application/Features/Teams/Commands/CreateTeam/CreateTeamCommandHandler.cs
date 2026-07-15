using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;
using System.Net;
using Team = MatchApi.Domain.Entities.Team;

namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, ResponseResult<string>>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(
        ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<ResponseResult<string>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if(await _teamRepository.isTeamExixst(request.SportId, request.Name, cancellationToken))
            {
                return new ResponseResult<string>
                {
                    Success = false,
                    Error = new Error
                    {
                        Message = "Team already exists for the given sport.",
                        StatusCode = HttpStatusCode.BadRequest.ToString()
                    }
                };
            }
            var team = Team.Create(request.Name, request.SportId, request.ColorHex);
            await _teamRepository.AddAsync(team, cancellationToken);
            return new ResponseResult<string> { Success = true, Message = "Team Created Successfully"};
        }
        catch (Exception ex)
        {
            return new ResponseResult<string> { Success = false, Error = new Error { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError.ToString()} };
        }
    }
}

