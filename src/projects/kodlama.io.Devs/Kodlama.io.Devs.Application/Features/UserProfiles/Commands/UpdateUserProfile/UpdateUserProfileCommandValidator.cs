using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandValidator:AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
    }
    }
}
