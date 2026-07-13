using MatchApi.Domain.Common;

namespace MatchApi.Domain.Entities
{
    public class Sport : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<SportRole> Roles { get; set; } = new List<SportRole>();

        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public static Sport Create(string name, Sport sport, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new InvalidOperationException("description is required.");
            }

            return new Sport
            {
                Name = name,
                Description = description
            };
        }
    }
}
