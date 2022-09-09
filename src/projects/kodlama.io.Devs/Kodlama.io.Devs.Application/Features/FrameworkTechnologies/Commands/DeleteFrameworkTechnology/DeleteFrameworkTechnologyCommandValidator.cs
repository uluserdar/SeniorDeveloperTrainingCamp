using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
