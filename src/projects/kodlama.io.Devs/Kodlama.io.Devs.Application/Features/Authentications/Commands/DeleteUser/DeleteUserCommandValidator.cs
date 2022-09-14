using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.DeleteUser
{
    public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
