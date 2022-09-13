using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class Group:Entity
    {
        public string Name { get; set; }

        public Group() { }

        public Group(string name):this()
        {
            Name = name;
        }
    }
}
