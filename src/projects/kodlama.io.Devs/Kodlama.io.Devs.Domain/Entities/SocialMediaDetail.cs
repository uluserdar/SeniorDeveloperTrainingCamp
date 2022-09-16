using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class SocialMediaDetail:Entity
    {
        public int UserProfileId { get; set; }
        public SocialMediaType SocialMediaType { get; set; }
        public string Url { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
