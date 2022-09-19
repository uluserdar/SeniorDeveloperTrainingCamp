using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRule>();
            services.AddScoped<FrameworkTechnologyBusinessRule>();
            services.AddScoped<AuthenticationBusinessRule>();
            services.AddScoped<OperationClaimBusinessRule>();
            services.AddScoped<UserProfileBusinessRule>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
