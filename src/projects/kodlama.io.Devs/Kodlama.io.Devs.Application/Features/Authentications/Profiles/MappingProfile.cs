using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser;

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
