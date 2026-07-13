
using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.SportRole.Queries.GetSportRoles;
using MediatR;
namespace MatchApi.Application.Features.SportRole.Queries.GetSportsRolesBySportId;
public class GetSportRolesBySportIdQueryHandler
    : IRequestHandler<GetSportRolesBySportIdQuery, List<GetSportRolesResponse>>
{
    private readonly ISportRoleRepository _repository;

    public GetSportRolesBySportIdQueryHandler(ISportRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSportRolesResponse>> Handle(
        GetSportRolesBySportIdQuery request,
        CancellationToken cancellationToken)
    {
        var roles = await _repository.GetSportRolesBySportIdAsync(request.SportId, cancellationToken);

        return roles.Select(x => new GetSportRolesResponse
        {
            RoleId = x.Id,
            RoleName = x.RoleName,
            SportId = x.SportId,
            Description = x.Description
        }).ToList();
    }
}