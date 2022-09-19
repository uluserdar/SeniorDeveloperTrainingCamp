using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand:IRequest<UpdatedUserProfileDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string GitHubUrl { get; set; }
        public string[] Roles => new[] { nameof(UpdateUserProfileCommand) };

        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly UserProfileBusinessRule _userProfileBusinessRule;

            public UpdateUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRule userProfileBusinessRule)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRule = userProfileBusinessRule;
            }

            public async Task<UpdatedUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = await _userProfileRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);
                _userProfileBusinessRule.CheckIfExistsUserProfile(userProfile);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile updatedUserProfile =await _userProfileRepository.UpdateAsync(mappedUserProfile);
                UpdatedUserProfileDto updatedUserProfileDto = _mapper.Map<UpdatedUserProfileDto>(updatedUserProfile);

                return updatedUserProfileDto;
            }
        }
    }
}
