using AutoMapper;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetListByIdFrameworkTechnology
{
    public class GetListByIdFrameworkTechnologyQuery:IRequest<FrameworkTechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetListByIdFrameworkTechnologyQueryHandler : IRequestHandler<GetListByIdFrameworkTechnologyQuery, FrameworkTechnologyGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;
            private readonly FrameworkTechnologyBusinessRule _frameworkTechnologyBusinessRule;

            public GetListByIdFrameworkTechnologyQueryHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository, FrameworkTechnologyBusinessRule frameworkTechnologyBusinessRule)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
                _frameworkTechnologyBusinessRule = frameworkTechnologyBusinessRule;
            }

            public async Task<FrameworkTechnologyGetByIdDto> Handle(GetListByIdFrameworkTechnologyQuery request, CancellationToken cancellationToken)
            {
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyShouldExistsWhenRequested(request.Id);
                FrameworkTechnology frameworkTechnology = await _frameworkTechnologyRepository.GetAsync(x => x.Id == request.Id);
                FrameworkTechnologyGetByIdDto frameworkTechnologyGetByIdDto = _mapper.Map<FrameworkTechnologyGetByIdDto>(frameworkTechnology);
                return frameworkTechnologyGetByIdDto;
            }
        }
    }
}
