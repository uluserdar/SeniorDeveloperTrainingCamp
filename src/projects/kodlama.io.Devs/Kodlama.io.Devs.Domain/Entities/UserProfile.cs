using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class UserProfile:Entity
    {
        public int UserId { get; set; }
        public string GitHubUrl { get; set; }

        public virtual User User { get; set; }
    }
}
