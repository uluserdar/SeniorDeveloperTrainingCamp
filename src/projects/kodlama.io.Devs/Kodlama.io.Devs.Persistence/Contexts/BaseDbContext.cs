using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.Versioning;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration;
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<FrameworkTechnology> FrameworkTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
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

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users");
                user.HasKey(k => k.Id);
                user.Property(p => p.FirstName).HasColumnName("FirstName");
                user.Property(p => p.LastName).HasColumnName("LastName");
                user.Property(p => p.Email).HasColumnName("Email");
                user.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                user.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                user.Property(p => p.Status).HasColumnName("Status");
                user.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                user.HasMany(user => user.UserOperationClaims);
                user.HasMany(user => user.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(oc =>
            {
                oc.ToTable("OperationClaims");
                oc.HasKey(k => k.Id);
                oc.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(uoc =>
            {
                uoc.ToTable("UserOperationClaims");
                uoc.HasKey(k => k.Id);
                uoc.Property(p => p.UserId).HasColumnName("UserId");
                uoc.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                uoc.HasOne(p => p.User);
                uoc.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<RefreshToken>(rt =>
            {
                rt.ToTable("RefreshTokens");
                rt.HasKey(k => k.Id);
                rt.Property(p => p.UserId).HasColumnName("UserId");
                rt.Property(p => p.Token).HasColumnName("Token");
                rt.Property(p => p.Expires).HasColumnName("Expires");
                rt.Property(p => p.Created).HasColumnName("Created");
                rt.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                rt.Property(p => p.Revoked).HasColumnName("Revoked");
                rt.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                rt.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                rt.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                rt.HasOne(p => p.User);
            });

            ProgrammingLanguage[] programmingLanguageSeeds = { new(1, "C#"), new(2, "Java"), new(3, "Pyton"), new(4, "Php") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeeds);

            FrameworkTechnology[] frameworkTechnologieSeeds = { new(1, 1, "ASP.NET"), new(2, 1, "WPF"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 3, "Django"), new(6, 4, "Laravel"), new(7, 4, "CodeIgniter") };
            modelBuilder.Entity<FrameworkTechnology>().HasData(frameworkTechnologieSeeds);
        }
    }
}
