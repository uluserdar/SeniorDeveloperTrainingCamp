using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Contexts;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context) { }
    }
}
