using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.DeleteFrameworkTechnology
{
    public class DeleteFrameworkTechnologyCommand:IRequest<DeletedFrameworkTechnologyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { nameof(DeleteFrameworkTechnologyCommand) };

        public class DeleteFrameworkTechnologyCommandHandler : IRequestHandler<DeleteFrameworkTechnologyCommand, DeletedFrameworkTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;
            private readonly FrameworkTechnologyBusinessRule _frameworkTechnologyBusinessRule;

            public DeleteFrameworkTechnologyCommandHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository, FrameworkTechnologyBusinessRule frameworkTechnologyBusinessRule)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
                _frameworkTechnologyBusinessRule = frameworkTechnologyBusinessRule;
            }

            public async Task<DeletedFrameworkTechnologyDto> Handle(DeleteFrameworkTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _frameworkTechnologyBusinessRule.FrameworkTechnologyShouldExistsWhenRequested(request.Id);

                FrameworkTechnology mappedFrameworkTechnology = _mapper.Map<FrameworkTechnology>(request);
                FrameworkTechnology deletedFrameworkTechnology =await _frameworkTechnologyRepository.DeleteAsync(mappedFrameworkTechnology);
                DeletedFrameworkTechnologyDto deletedFrameworkTechnologyDto = _mapper.Map<DeletedFrameworkTechnologyDto>(deletedFrameworkTechnology);

                return deletedFrameworkTechnologyDto;
            }
        }
    }
}
