using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimcommandValidator:AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimcommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
