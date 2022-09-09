using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.UpdateFrameworkTechnology
{
    public class UpdateFrameworkTechnologyCommandValidator:AbstractValidator<UpdateFrameworkTechnologyCommand>
    {
        public UpdateFrameworkTechnologyCommandValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
            RuleFor(x=> x.Id).NotNull();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x => x.ProgrammingLanguageId).NotNull();
            RuleFor(x => x.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
