using AutoMapper;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule _programmingLanguageBusinessRule;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programmingLanguageBusinessRule)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRule = programmingLanguageBusinessRule;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                _programmingLanguageBusinessRule.ProgrammingLanguageNameIsNotBeNullOrEmpty(request.Name);
                await _programmingLanguageBusinessRule.ProgrammmingLanguageNameCanNotBeDublicatedWhenInserted(request.Name);

                ProgrammingLanguage programmingLanguage=_mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(programmingLanguage);
                CreateProgrammingLanguageDto createProgrammingLanguageDto=_mapper.Map<CreateProgrammingLanguageDto>(createdProgrammingLanguage);
                return createProgrammingLanguageDto;
            }
        }
    }
}
