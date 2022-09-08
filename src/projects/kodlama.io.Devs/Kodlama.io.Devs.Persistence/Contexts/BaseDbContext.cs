using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration;
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<FrameworkTechnology> FrameworkTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguages");
                pl.HasKey(k=> k.Id);
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");
                pl.HasMany(p => p.FrameworkTechnologies);
            });

            modelBuilder.Entity<FrameworkTechnology>(ft =>
            {
                ft.ToTable("FrameworkTechnologies");
                ft.HasKey(k => k.Id);
                ft.Property(p => p.Id).HasColumnName("Id");
                ft.Property(p => p.Name).HasColumnName("Name");
                ft.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                ft.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] programmingLanguageSeeds = { new(1, "C#"), new(2, "Java"), new(3, "Pyton"), new(4, "Php") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeeds);

            FrameworkTechnology[] frameworkTechnologieSeeds = { new(1, 1, "ASP.NET"), new(2, 1, "WPF"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 3, "Django"), new(6, 4, "Laravel"), new(7, 4, "CodeIgniter") };
            modelBuilder.Entity<FrameworkTechnology>().HasData(frameworkTechnologieSeeds);
        }
    }
}
