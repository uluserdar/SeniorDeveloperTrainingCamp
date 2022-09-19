using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfile, CreatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile,UpdatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, DeletedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(x=>x.FirstName,opt=>opt.MapFrom(x=>x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
                .ReverseMap();
            CreateMap<IPaginate<UserProfile>, UserProfileListModel>().ReverseMap();
        }
    }
}
