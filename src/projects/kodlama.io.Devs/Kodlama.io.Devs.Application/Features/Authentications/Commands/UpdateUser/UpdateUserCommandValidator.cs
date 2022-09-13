using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UpdateUser
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(4);
            RuleFor(x => x.FirstName).MaximumLength(50);
            RuleFor(x => x.LastName).MaximumLength(50);

        }
    }
}
