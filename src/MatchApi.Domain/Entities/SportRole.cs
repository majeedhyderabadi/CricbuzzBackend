using MatchApi.Domain.Common;

namespace MatchApi.Domain.Entities
{
    public class SportRole : BaseEntity
    {
        public Guid SportId { get; set; }

        public Sport Sport { get; set; } = null!;

        public string RoleName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public static SportRole Create(
            Guid sportId,
            string roleName,
            string description)
        {
            if (sportId == Guid.Empty)
                throw new InvalidOperationException("Sport is required.");

            if (string.IsNullOrWhiteSpace(roleName))
                throw new InvalidOperationException("Role name is required.");

            return new SportRole
            {
                SportId = sportId,
                RoleName = roleName,
                Description = description
            };
        }
    }
}
