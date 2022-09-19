using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
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

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand:IRequest<CreatedUserProfileDto>,ISecuredRequest
    {
        public int UserId { get; set; }
        public string GitHubUrl { get; set; }
        public string[] Roles => new[] { nameof(CreateUserProfileCommand) };

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IUserRepository _userRepository;
            private readonly UserProfileBusinessRule _userProfileBusinessRule;

            public CreateUserProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRule userProfileBusinessRule, IUserRepository userRepository)
            {
                this._mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRule = userProfileBusinessRule;
                _userRepository = userRepository;
            }

            public async Task<CreatedUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Id == request.UserId,enableTracking:false);
                UserProfile userProfile = await _userProfileRepository.GetAsync(x => x.GitHubUrl == request.GitHubUrl, enableTracking: false);
                _userProfileBusinessRule.CheckIfExistsUser(user);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile addedUserProfile =await _userProfileRepository.AddAsync(mappedUserProfile);
                CreatedUserProfileDto createdUserProfileDto=_mapper.Map<CreatedUserProfileDto>(addedUserProfile);

                return createdUserProfileDto;
            }
        }
    }
}
