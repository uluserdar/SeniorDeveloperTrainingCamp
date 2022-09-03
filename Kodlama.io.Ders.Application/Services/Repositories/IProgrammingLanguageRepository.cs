using Core.Persistence.Repositories;
using Kodlama.io.Ders.Domain.Entities;

namespace Kodlama.io.Ders.Application.Services.Repositories
{
    public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>, IRepository<ProgrammingLanguage> { }
}
