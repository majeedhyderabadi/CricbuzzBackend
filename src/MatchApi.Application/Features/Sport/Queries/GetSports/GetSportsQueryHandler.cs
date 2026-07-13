using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Sport.Queries.GetSports;
using MediatR;

public class GetSportsQueryHandler
    : IRequestHandler<GetSportsQuery, List<GetSportsResponse>>
{
    private readonly ISportRepository _repository;

    public GetSportsQueryHandler(ISportRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSportsResponse>> Handle(
        GetSportsQuery request,
        CancellationToken cancellationToken)
    {
        var sports = await _repository.GetSortsAsync(cancellationToken);

        return sports.Select(x => new GetSportsResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            SportRoles = x.Roles.Select(sr => new GetSportRoleResponse
            {
                RoleId = sr.Id,
                RoleName = sr.RoleName,
                Description = sr.Description
            }).ToList()
        }).ToList();
    }
}