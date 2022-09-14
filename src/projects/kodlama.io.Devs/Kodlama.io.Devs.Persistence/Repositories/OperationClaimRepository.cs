using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Contexts;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context) { }
    }
}
