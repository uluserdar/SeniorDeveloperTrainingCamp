using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class UserGroup:Entity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }

        public UserGroup() { }

        public UserGroup(int userId, int groupId):this()
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}
