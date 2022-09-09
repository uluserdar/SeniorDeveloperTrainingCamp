using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.DeleteFrameworkTechnology
{
    public class DeleteFrameworkTechnologyCommandValidator:AbstractValidator<DeleteFrameworkTechnologyCommand>
    {
        public DeleteFrameworkTechnologyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
