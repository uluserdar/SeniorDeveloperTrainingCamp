using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommand:IRequest<DeletedUserProfileDto>
    {
        public int Id { get; set; }

        public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly UserProfileBusinessRule _userProfileBusinessRule;

            public DeleteUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRule userProfileBusinessRule)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRule = userProfileBusinessRule;
            }

            public async Task<DeletedUserProfileDto> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = await _userProfileRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);
                _userProfileBusinessRule.CheckIfExistsUserProfile(userProfile);

                UserProfile deletesUserProfile = await _userProfileRepository.DeleteAsync(userProfile);
                DeletedUserProfileDto deletedUserProfileDto = _mapper.Map<DeletedUserProfileDto>(deletesUserProfile);

                return deletedUserProfileDto;
            }
        }
    }
}
