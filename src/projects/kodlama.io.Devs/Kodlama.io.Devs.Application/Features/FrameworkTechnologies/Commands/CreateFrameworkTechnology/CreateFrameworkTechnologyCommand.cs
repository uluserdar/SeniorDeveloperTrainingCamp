using AutoMapper;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.CreateFrameworkTechnology
{
    public class CreateFrameworkTechnologyCommand : IRequest<CreatedFrameworkTechnologyDto>
    {
        public string Name { get; set; }

        public class CreateFrameworkTechnologyCommandHandler : IRequestHandler<CreateFrameworkTechnologyCommand, CreatedFrameworkTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;

            public CreateFrameworkTechnologyCommandHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
            }

            public async Task<CreatedFrameworkTechnologyDto> Handle(CreateFrameworkTechnologyCommand request, CancellationToken cancellationToken)
            {
                FrameworkTechnology mappedFrameworkTechnology = _mapper.Map<FrameworkTechnology>(request);
                FrameworkTechnology createdFrameworkTechnology = await _frameworkTechnologyRepository.AddAsync(mappedFrameworkTechnology);
                CreatedFrameworkTechnologyDto createdFrameworkTechnologyDto=_mapper.Map<CreatedFrameworkTechnologyDto>(createdFrameworkTechnology);
                return createdFrameworkTechnologyDto;
            }
        }
    }
}
