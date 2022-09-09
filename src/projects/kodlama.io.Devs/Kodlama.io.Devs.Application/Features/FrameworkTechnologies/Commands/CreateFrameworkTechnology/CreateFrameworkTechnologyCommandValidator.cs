using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology
{
    public class CreateFrameworkTechnologyCommandValidator:AbstractValidator<CreateFrameworkTechnologyCommand>
    {
        public CreateFrameworkTechnologyCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x => x.ProgrammingLanguageId).NotNull();
            RuleFor(x => x.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
