using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.SportRole.Commands.AddSportRole
{
    public class CreateSportRoleCommandHandler
      : IRequestHandler<CreateSportRoleCommand, ResponseResult<string>>
    {
        private readonly ISportRoleRepository _repository;

        public CreateSportRoleCommandHandler(ISportRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<string>> Handle(
            CreateSportRoleCommand request,
            CancellationToken cancellationToken)
        {
            if(await _repository.isSportRoleExixst(request.SportId, request.RoleName, cancellationToken))
            {
                return new ResponseResult<string>
                {
                    Success = false,
                    Error = new Error
                    {
                        StatusCode = HttpStatusCode.BadRequest.ToString(),
                        Message = $"Sport role '{request.RoleName}' already exists for given sport."
                    }
                };
            }
            var role = new Domain.Entities.SportRole
            {
                Id = Guid.NewGuid(),
                SportId = request.SportId,
                RoleName = request.RoleName,
                Description = request.Description,
            };

            await _repository.AddSportRoleAsync(role, cancellationToken);

            return new ResponseResult<string>
            {
                Success = true,
                Message = "Sport role created successfully.",
            };
        }
    }
}
