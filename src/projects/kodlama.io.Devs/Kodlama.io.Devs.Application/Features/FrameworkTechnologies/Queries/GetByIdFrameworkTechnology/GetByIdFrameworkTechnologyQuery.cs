using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Queries.GetByIdFrameworkTechnology
{
    public class GetByIdFrameworkTechnologyQuery:IRequest<FrameworkTechnologyGetByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { nameof(GetByIdFrameworkTechnologyQuery) };

        public class GetListByIdFrameworkTechnologyQueryHandler : IRequestHandler<GetByIdFrameworkTechnologyQuery, FrameworkTechnologyGetByIdDto>
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

            public async Task<FrameworkTechnologyGetByIdDto> Handle(GetByIdFrameworkTechnologyQuery request, CancellationToken cancellationToken)
            {
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyShouldExistsWhenRequested(request.Id);
                FrameworkTechnology frameworkTechnology = await _frameworkTechnologyRepository.GetAsync(x => x.Id == request.Id);
                FrameworkTechnologyGetByIdDto frameworkTechnologyGetByIdDto = _mapper.Map<FrameworkTechnologyGetByIdDto>(frameworkTechnology);
                return frameworkTechnologyGetByIdDto;
            }
        }
    }
}
