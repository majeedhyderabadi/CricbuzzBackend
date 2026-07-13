namespace MatchApi.Application.Features.SportRole.Queries.GetSportRoles
{
    public class GetSportRolesResponse
    {
        public Guid RoleId { get; set; }
        public Guid SportId { get; set; }

        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
