using AutoMapper;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.UpdateFrameworkTechnology
{
    public class UpdateFrameworkTechnologyCommand : IRequest<UpdatedFrameworkTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateFrameworkTechnologyCommandHandler : IRequestHandler<UpdateFrameworkTechnologyCommand, UpdatedFrameworkTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;
            private readonly FrameworkTechnologyBusinessRule _frameworkTechnologyBusinessRule;

            public UpdateFrameworkTechnologyCommandHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository, FrameworkTechnologyBusinessRule frameworkTechnologyBusinessRule)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
                _frameworkTechnologyBusinessRule = frameworkTechnologyBusinessRule;
            }

            public async Task<UpdatedFrameworkTechnologyDto> Handle(UpdateFrameworkTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyShouldExistsWhenRequested(request.Id);
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyNameCanNotBeDublicatedWhenUpdated(request.Id, request.Name);
                
                FrameworkTechnology mappedFrameworkTechnology = _mapper.Map<FrameworkTechnology>(request);
                FrameworkTechnology updatedFrameworkTechnology =await _frameworkTechnologyRepository.UpdateAsync(mappedFrameworkTechnology);
                UpdatedFrameworkTechnologyDto updatedFrameworkTechnologyDto=_mapper.Map<UpdatedFrameworkTechnologyDto>(updatedFrameworkTechnology);
                return updatedFrameworkTechnologyDto;

            }
        }
    }
}
