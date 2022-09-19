using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfile
{
    public class GetListUserProfileQuery:IRequest<UserProfileListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] {nameof(GetListUserProfileQuery)}; 

        public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, UserProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;

            public GetListUserProfileQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
            }

            public async Task<UserProfileListModel> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListAsync(
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize,
                    include:x=>x.Include(up=>up.User));

                UserProfileListModel userProfileListModel = _mapper.Map<UserProfileListModel>(userProfiles);
                return userProfileListModel;
            }
        }
    }
}
