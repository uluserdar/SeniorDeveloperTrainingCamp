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

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Commands.UpdateFrameworkTechnology
{
    public class UpdateFrameworkTechnologyCommand : IRequest<UpdatedFrameworkTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFrameworkTechnologyCommandHandler : IRequestHandler<UpdateFrameworkTechnologyCommand, UpdatedFrameworkTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;

            public UpdateFrameworkTechnologyCommandHandler(IMapper mapper, IFrameworkTechnologyRepository frameworkTechnologyRepository)
            {
                _mapper = mapper;
                _frameworkTechnologyRepository = frameworkTechnologyRepository;
            }

            public async Task<UpdatedFrameworkTechnologyDto> Handle(UpdateFrameworkTechnologyCommand request, CancellationToken cancellationToken)
            {
                FrameworkTechnology mappedFrameworkTechnology = _mapper.Map<FrameworkTechnology>(request);
                FrameworkTechnology updatedFrameworkTechnology =await _frameworkTechnologyRepository.UpdateAsync(mappedFrameworkTechnology);
                UpdatedFrameworkTechnologyDto updatedFrameworkTechnologyDto=_mapper.Map<UpdatedFrameworkTechnologyDto>(updatedFrameworkTechnology);
                return updatedFrameworkTechnologyDto;

            }
        }
    }
}
