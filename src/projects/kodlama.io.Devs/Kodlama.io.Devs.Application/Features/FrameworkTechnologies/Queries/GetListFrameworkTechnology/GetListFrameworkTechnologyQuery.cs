using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetListFrameworkTechnology
{
    public class GetListFrameworkTechnologyQuery:IRequest<FrameworkTechnologyListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] {nameof(GetListFrameworkTechnologyQuery) };

        public class GetListFrameworkTechnologyQueryHandler : IRequestHandler<GetListFrameworkTechnologyQuery, FrameworkTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;

            public GetListFrameworkTechnologyQueryHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
            }

            public async Task<FrameworkTechnologyListModel> Handle(GetListFrameworkTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<FrameworkTechnology> frameworkTechnologies = await _frameworkTechnologyRepository.GetListAsync(
                    include:x=> x.Include(c=> c.ProgrammingLanguage),
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize);

                FrameworkTechnologyListModel frameworkTechnologyListModel = _mapper.Map<FrameworkTechnologyListModel>(frameworkTechnologies);
                return frameworkTechnologyListModel;
            }
        }
    }
}
