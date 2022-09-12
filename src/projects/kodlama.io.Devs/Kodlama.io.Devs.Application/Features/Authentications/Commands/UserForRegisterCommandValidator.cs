using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands
{
    public class UserForRegisterCommandValidator:AbstractValidator<UserForRegisterCommand>
    {
        public UserForRegisterCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(4);
            RuleFor(x => x.FirstName).MaximumLength(50);
            RuleFor(x => x.LastName).MaximumLength(50);
        }
    }
}
