using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Contexts;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class UserProfileRepository : EfRepositoryBase<UserProfile, BaseDbContext>, IUserProfileRepository
    {
        public UserProfileRepository(BaseDbContext context) : base(context) { }
    }
}
