using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            public readonly OperationClaimBusinessRule _operationClaimBusinessRule;

            public UpdateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRule operationClaimBusinessRule)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRule = operationClaimBusinessRule;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                _operationClaimBusinessRule.CheckIfExistsOperationClaim(operationClaim);

                OperationClaim mappedOperationClaim =_mapper.Map<OperationClaim>(operationClaim);
                OperationClaim updatedOperationClaim =await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

                return updatedOperationClaimDto;
            }
        }
    }
}
