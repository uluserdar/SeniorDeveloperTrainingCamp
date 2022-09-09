using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Rules
{
    public class FrameworkTechnologyBusinessRule
    {
        private readonly IFrameworkTechnologyRepository _frameworkTechnologyRepository;

        public FrameworkTechnologyBusinessRule(IFrameworkTechnologyRepository frameworkTechnologyRepository)
        {
            _frameworkTechnologyRepository = frameworkTechnologyRepository;
        }
        public async Task FrameworkTechnologyNameCanNotBeDublicatedWhenInserted(string name)
        {
            var result=await _frameworkTechnologyRepository.GetListAsync(ft=> ft.Name==name);
            if (result.Items.Any()) throw new BusinessException(FrameworkTechnologyMessages.FrameworkTechnologyNameExistsMessage);
        }

        public async Task FrameworkTechnologyNameCanNotBeDublicatedWhenUpdated(int id, string name)
        {
            IPaginate<FrameworkTechnology> result = await _frameworkTechnologyRepository.GetListAsync(pl => pl.Name == name && pl.Id != id);
            if (result.Items.Any()) throw new BusinessException(FrameworkTechnologyMessages.FrameworkTechnologyNameExistsMessage);
        }

        public async Task FrameworkTechnologyShouldExistsWhenRequested(int id)
        {
            var result = await _frameworkTechnologyRepository.GetAsync(pl => pl.Id == id);
            if (result == null) throw new BusinessException(FrameworkTechnologyMessages.FrameworkTechnologyShouldExistsWhenRequestMessage);
        }
    }
}
