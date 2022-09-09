using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
