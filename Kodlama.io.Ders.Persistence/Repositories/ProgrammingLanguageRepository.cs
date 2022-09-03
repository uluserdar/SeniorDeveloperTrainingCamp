using Core.Persistence.Repositories;
using Kodlama.io.Ders.Application.Services.Repositories;
using Kodlama.io.Ders.Domain.Entities;
using Kodlama.io.Ders.Persistence.Contexts;

namespace Kodlama.io.Ders.Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context) { }
    }
}
