using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology
{
    public class CreateFrameworkTechnologyCommand : IRequest<CreatedFrameworkTechnologyDto>,ISecuredRequest
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string[] Roles => new[] { nameof(CreateFrameworkTechnologyCommand) };

        public class CreateFrameworkTechnologyCommandHandler : IRequestHandler<CreateFrameworkTechnologyCommand, CreatedFrameworkTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;
            private readonly FrameworkTechnologyBusinessRule _frameworkTechnologyBusinessRule;

            public CreateFrameworkTechnologyCommandHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository, FrameworkTechnologyBusinessRule frameworkTechnologyBusinessRule)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
                _frameworkTechnologyBusinessRule = frameworkTechnologyBusinessRule;
            }

            public async Task<CreatedFrameworkTechnologyDto> Handle(CreateFrameworkTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyNameCanNotBeDublicatedWhenInserted(request.Name);
                await _frameworkTechnologyBusinessRule.ProgrammingLanguageShouldExistsWhenRequested(request.ProgrammingLanguageId);

                FrameworkTechnology mappedFrameworkTechnology = _mapper.Map<FrameworkTechnology>(request);
                FrameworkTechnology createdFrameworkTechnology = await _frameworkTechnologyRepository.AddAsync(mappedFrameworkTechnology);
                CreatedFrameworkTechnologyDto createdFrameworkTechnologyDto=_mapper.Map<CreatedFrameworkTechnologyDto>(createdFrameworkTechnology);
                return createdFrameworkTechnologyDto;
            }
        }
    }
}
