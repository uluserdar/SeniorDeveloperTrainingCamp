using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator:AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotEmpty();
            RuleFor(pl => pl.Id).NotNull();
            RuleFor(pl => pl.Id).GreaterThan(0);
        }
    }
}
