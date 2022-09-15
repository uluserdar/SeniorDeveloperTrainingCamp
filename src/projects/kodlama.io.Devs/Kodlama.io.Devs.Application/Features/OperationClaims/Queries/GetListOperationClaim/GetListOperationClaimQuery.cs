using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListByDynamicOperationClaim;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery:IRequest<OperationClaimListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { nameof(GetListOperationClaimQuery) };

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;

            public GetListOperationClaimQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

                return operationClaimListModel;
            }
        }
    }
}
