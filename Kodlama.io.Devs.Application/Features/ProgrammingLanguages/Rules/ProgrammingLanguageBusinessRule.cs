using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constans;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRule
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRule(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammmingLanguageNameCanNotBeDublicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguageNameExistsMessage);
        }

        public void ProgrammingLanguageNameIsNotBeNullOrEmpty(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new BusinessException(Messages.ProgrammingLanguageNameIsNotNullOrEmptyMessage);
        }
    }
}
