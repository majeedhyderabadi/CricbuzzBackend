
namespace MatchApi.Application.Features.SportRole.Commands.AddSportRole
{
    public class CreateSportRoleResponse
    {
        public Guid RoletId { get; set; }
        public Guid SportId { get; set; }

        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
