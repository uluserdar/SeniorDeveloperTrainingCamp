using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser
{
    public class LoginUserQueryValidator:AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(4);
        }
    }
}
