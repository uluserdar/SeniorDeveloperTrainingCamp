using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetByIdUserProfile
{
    public class GetByIdUserProfileQuery:IRequest<UserProfileDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { nameof(GetByIdUserProfileQuery) };

        public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;

            public GetByIdUserProfileQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
            }

            public async Task<UserProfileDto> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = await _userProfileRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    include:x=> x.Include(up=> up.User)
                    );

                UserProfileDto userProfileDto = _mapper.Map<UserProfileDto>(userProfile);

                return userProfileDto;
            }
        }
    }
}
