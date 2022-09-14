using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand:IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

            public CreateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRule operationClaimBusinessRule)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRule = operationClaimBusinessRule;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == request.Name);
                _operationClaimBusinessRule.CheckIfExistsOperationClaim(operationClaim);

                OperationClaim addeOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);
                CreatedOperationClaimDto createdOperationClaimDto=_mapper.Map<CreatedOperationClaimDto>(addeOperationClaim);

                return createdOperationClaimDto;
            }
        }
    }
}
