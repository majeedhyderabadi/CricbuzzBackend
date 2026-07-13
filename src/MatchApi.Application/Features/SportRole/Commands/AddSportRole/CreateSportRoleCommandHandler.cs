using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.SportRole.Commands.AddSportRole
{
    public class CreateSportRoleCommandHandler
      : IRequestHandler<CreateSportRoleCommand, CreateSportRoleResponse>
    {
        private readonly ISportRoleRepository _repository;

        public CreateSportRoleCommandHandler(ISportRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSportRoleResponse> Handle(
            CreateSportRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = new Domain.Entities.SportRole
            {
                Id = Guid.NewGuid(),
                SportId = request.SportId,
                RoleName = request.RoleName,
                Description = request.Description,
            };

            await _repository.AddSportRoleAsync(role, cancellationToken);

            return new CreateSportRoleResponse
            {
                RoletId = role.Id,
                SportId = role.SportId,
                RoleName = role.RoleName
            };
        }
    }
}
