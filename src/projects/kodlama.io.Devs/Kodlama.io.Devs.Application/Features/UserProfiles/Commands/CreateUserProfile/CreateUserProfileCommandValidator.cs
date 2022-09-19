using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandValidator:AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
