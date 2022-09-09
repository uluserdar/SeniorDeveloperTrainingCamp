using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FrameworkTechnology, CreatedFrameworkTechnologyDto>().ReverseMap();
            CreateMap<FrameworkTechnology, UpdatedFrameworkTechnologyDto>().ReverseMap();
            CreateMap<FrameworkTechnology, DeletedFrameworkTechnologyDto>().ReverseMap();
            CreateMap<FrameworkTechnology,FrameworkTechnologyListDto>().ForMember(x=> x.ProgrammingLanguageName,opt=> opt.MapFrom(x=> x.ProgrammingLanguage.Name)).ForMember(x=> x.FrameworkTechnologyName,opt=> opt.MapFrom(x=> x.Name)).ReverseMap();
            CreateMap<IPaginate<FrameworkTechnology>, FrameworkTechnologyListModel>().ReverseMap();
            CreateMap<FrameworkTechnology, FrameworkTechnologyGetByIdDto>().ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name)).ForMember(x => x.FrameworkTechnologyName, opt => opt.MapFrom(x => x.Name)).ReverseMap();
        }
    }
}
