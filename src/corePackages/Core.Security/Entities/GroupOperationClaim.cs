using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class GroupOperationClaim:Entity
    {
        public int GroupId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual Group Group { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

        public GroupOperationClaim() { }

        public GroupOperationClaim(int groupId, int claimId)
        {
            GroupId = groupId;
            OperationClaimId = claimId;
        }
    }
}
