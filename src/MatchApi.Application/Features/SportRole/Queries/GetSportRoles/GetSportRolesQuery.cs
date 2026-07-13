using MediatR;

namespace MatchApi.Application.Features.SportRole.Queries.GetSportRoles
{
    public record GetSportRolesQuery()
     : IRequest<List<GetSportRolesResponse>>;
}
