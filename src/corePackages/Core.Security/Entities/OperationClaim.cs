using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public OperationClaim()
    {
        UserOperationClaims=new HashSet<UserOperationClaim>();
    }

    public OperationClaim(int id, string name) : base(id)
    {
        Name = name;
    }
}