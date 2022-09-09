using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constans;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

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
            if (result.Items.Any()) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNameExistsMessage);
        }

        public async Task ProgrammmingLanguageNameCanNotBeDublicatedWhenUpdated(int id,string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name && pl.Id!=id);
            if (result.Items.Any()) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNameExistsMessage);
        }

        public async Task ProgrammingLanguageShouldExistsWhenRequested(int id)
        {
            var result = await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);
            if (result == null) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageShouldExistsWhenRequestMessage);
        }
    }
}
