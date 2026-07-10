using MatchApi.Application.Features.SportRole.Queries.GetSportRoles;
using MediatR;

namespace MatchApi.Application.Features.SportRole.Queries.GetSportsRolesBySportId
{
    public record GetSportRolesBySportIdQuery(Guid SportId)
     : IRequest<List<GetSportRolesResponse>>;
}
