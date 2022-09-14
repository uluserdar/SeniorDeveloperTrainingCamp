using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.DeleteUser;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UpdateUser;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Models;
using Kodlama.io.Devs.Application.Features.Authentications.Queries.GetByIdUser;
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
            CreateMap<User,UpdatedUserDto>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User,UserGetByIdDto>().ReverseMap();
            CreateMap<User, GetByIdUserQuery>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
        }
    }
}
