using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GroupOperationClaim> GroupOperationClaims { get; set; }   

        public Group()
        {
            Users = new HashSet<User>();
            GroupOperationClaims = new HashSet<GroupOperationClaim>();
        }

        public Group(string name) : this()
        {
            Name = name;
        }
    }
}
