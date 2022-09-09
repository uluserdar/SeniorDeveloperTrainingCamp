using AutoMapper;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FrameworkTechnology, CreatedFrameworkTechnologyDto>().ReverseMap();
            CreateMap<FrameworkTechnology, UpdatedFrameworkTechnologyDto>().ReverseMap();
        }
    }
}
