using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotEmpty();
            RuleFor(pl => pl.Id).NotNull();
            RuleFor(pl => pl.Id).GreaterThan(0);
            RuleFor(pl => pl.Name).NotEmpty();
            RuleFor(pl => pl.Name).MaximumLength(20);
        }
    }
}
