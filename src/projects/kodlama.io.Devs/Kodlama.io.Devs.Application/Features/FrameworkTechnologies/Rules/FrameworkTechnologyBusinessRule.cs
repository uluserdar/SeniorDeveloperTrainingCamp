using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
