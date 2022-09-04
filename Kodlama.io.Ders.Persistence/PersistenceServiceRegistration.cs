using Kodlama.io.Ders.Application.Services.Repositories;
using Kodlama.io.Ders.Persistence.Contexts;
using Kodlama.io.Ders.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Ders.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDersConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository,ProgrammingLanguageRepository>();

            return services;
        }
    }
}
