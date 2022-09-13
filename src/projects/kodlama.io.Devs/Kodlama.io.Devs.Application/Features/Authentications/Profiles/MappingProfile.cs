using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser;
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
            CreateMap<User, RegisteredUserDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, LoginUserQuery>().ReverseMap();
            CreateMap<User, LoggedUserDto>().ReverseMap();
            CreateMap<LoggedUserDto,LoginUserQuery>().ReverseMap();
        }
    }
}
