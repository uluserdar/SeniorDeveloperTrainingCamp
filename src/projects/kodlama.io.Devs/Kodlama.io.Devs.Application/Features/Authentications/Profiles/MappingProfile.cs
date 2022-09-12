using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UserForRegisterCommand>().ReverseMap();
        }
    }
}
