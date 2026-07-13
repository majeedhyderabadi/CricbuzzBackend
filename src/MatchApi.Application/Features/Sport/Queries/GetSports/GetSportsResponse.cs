
namespace MatchApi.Application.Features.Sport.Queries.GetSports
{
    public class GetSportsResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<GetSportRoleResponse> SportRoles { get; set; } = new List<GetSportRoleResponse>();

    }
    public class GetSportRoleResponse
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
