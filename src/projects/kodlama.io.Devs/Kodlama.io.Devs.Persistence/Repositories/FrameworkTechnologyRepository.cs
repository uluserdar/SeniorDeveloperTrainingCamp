using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class FrameworkTechnologyRepository : EfRepositoryBase<FrameworkTechnology, BaseDbContext>, IFrameworkTechnologyRepository
    {
        public FrameworkTechnologyRepository(BaseDbContext context) : base(context) { }
    }
}
