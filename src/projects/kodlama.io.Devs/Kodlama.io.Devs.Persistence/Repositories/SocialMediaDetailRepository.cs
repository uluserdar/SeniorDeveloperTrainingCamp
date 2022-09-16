using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Contexts;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class SocialMediaDetailRepository : EfRepositoryBase<SocialMediaDetail, BaseDbContext>, ISocialMediaDetailRepository
    {
        public SocialMediaDetailRepository(BaseDbContext context) : base(context) { }
    }
}
