using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommandValidator:AbstractValidator<DeleteUserProfileCommand>
    {
        public DeleteUserProfileCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
