
using MatchApi.Application.Common.Interfaces;
using MediatR;
namespace MatchApi.Application.Features.SportRole.Queries.GetSportRoles;
public class GetSportRolesQueryHandler
    : IRequestHandler<GetSportRolesQuery, List<GetSportRolesResponse>>
{
    private readonly ISportRoleRepository _repository;

    public GetSportRolesQueryHandler(ISportRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSportRolesResponse>> Handle(
        GetSportRolesQuery request,
        CancellationToken cancellationToken)
    {
        var roles = await _repository.GetSportRolesAsync(
            cancellationToken);

        return roles.Select(x => new GetSportRolesResponse
        {
            RoleId = x.Id,
            RoleName = x.RoleName,
            SportId = x.SportId,
            Description = x.Description
        }).ToList();
    }
}