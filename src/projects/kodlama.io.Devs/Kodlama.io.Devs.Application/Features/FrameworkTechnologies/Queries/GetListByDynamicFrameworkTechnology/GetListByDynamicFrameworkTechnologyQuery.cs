using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetListByDynamicFrameworkTechnology
{
    public class GetListByDynamicFrameworkTechnologyQuery:IRequest<FrameworkTechnologyListModel>,ISecuredRequest
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { nameof(GetListByDynamicFrameworkTechnologyQuery) };

        public class GetListByDynamicFrameworkTechnologyQueryHandler : IRequestHandler<GetListByDynamicFrameworkTechnologyQuery, FrameworkTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;

            public GetListByDynamicFrameworkTechnologyQueryHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
            }

            public async Task<FrameworkTechnologyListModel> Handle(GetListByDynamicFrameworkTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<FrameworkTechnology> frameworkTechnologies = await _frameworkTechnologyRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: x => x.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                FrameworkTechnologyListModel frameworkTechnologyListModel = _mapper.Map<FrameworkTechnologyListModel>(frameworkTechnologies);
                return frameworkTechnologyListModel;
            }
        }
    }
}
