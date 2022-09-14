using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Hashing;
using System.Reflection;

namespace Kodlama.io.Devs.Application.Helpers
{
    public static class OperationClaimCreatorMiddleware
    {
        static IUserRepository _userRepository;
        static IOperationClaimRepository _operationClaimRepository;
        static IUserOperationClaimRepository _userOperationClaimRepository;

        public static async Task UseDbOperationClaimCreator(this IApplicationBuilder app)
        {
            _userRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IUserRepository>();
            _operationClaimRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IOperationClaimRepository>();
            _userOperationClaimRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IUserOperationClaimRepository>();

            User user = await _userRepository.GetAsync(x => x.Email == "admin@admin.com");
            
            await AddOperationClaim(user);
        }

        private static async Task<User> AddUser(User user)
        {
            HashingHelper.CreatePasswordHash("Admin1234", out var passwordHash, out var passwordSalt);
            if (user == null) user = await _userRepository.AddAsync(new User { FirstName = "System", LastName = "Admin", Email = "admin@admin.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Status = true });

            return user;
        }

        private static async Task AddOperationClaim(User user)
        {
            user = await AddUser(user);
            foreach (var item in GetOperationNames())
            {
                OperationClaim operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == item);
                if (operationClaim == null)
                {
                    OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(new OperationClaim { Name = item });
                    await _userOperationClaimRepository.AddAsync(new UserOperationClaim { OperationClaimId = addedOperationClaim.Id, UserId = user.Id });
                }
            }
        }

        private static IEnumerable<string> GetOperationNames()
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(x =>
                     // runtime generated anonmous type'larin assemblysi olmadigi icin null cek yap
                     x.Namespace != null && x.Namespace.StartsWith("Kodlama.io.Devs.Application.Features") &&
                      ((x.Name.EndsWith("Command") || x.Name.EndsWith("Query")) && x.GetInterfaces().FirstOrDefault(x => x.Name == "ISecuredRequest") != null))
            .Select(x => x.Name);
            return assemblyNames;
        }
    }
}
