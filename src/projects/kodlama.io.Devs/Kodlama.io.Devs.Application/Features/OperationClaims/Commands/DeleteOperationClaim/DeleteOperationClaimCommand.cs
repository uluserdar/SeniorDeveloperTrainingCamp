using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand:IRequest<DeletedOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { nameof(DeleteOperationClaimCommand) };

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

            public DeleteOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRule operationClaimBusinessRule)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRule = operationClaimBusinessRule;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                _operationClaimBusinessRule.CheckIfExistsOperationClaim(operationClaim);

                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
                DeletedOperationClaimDto deletedOperationClaimDto=_mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

                return deletedOperationClaimDto;
            }
        }
    }
}
