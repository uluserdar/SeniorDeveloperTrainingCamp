using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology
{
    public class CreateFrameworkTechnologyCommandValidator:AbstractValidator<CreateFrameworkTechnologyCommand>
    {
        public CreateFrameworkTechnologyCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20);
        }
    }
}
