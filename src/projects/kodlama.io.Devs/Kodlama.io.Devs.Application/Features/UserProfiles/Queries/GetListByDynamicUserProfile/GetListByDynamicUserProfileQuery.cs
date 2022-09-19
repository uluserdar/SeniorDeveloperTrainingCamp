using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListByDynamicUserProfile
{
    public class GetListByDynamicUserProfileQuery : IRequest<UserProfileListModel>, ISecuredRequest
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[]{nameof(GetListByDynamicUserProfileQuery)};

        public class GetListByDynamicUserProfileQueryHandler : IRequestHandler<GetListByDynamicUserProfileQuery, UserProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;

            public GetListByDynamicUserProfileQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
            }

            public async Task<UserProfileListModel> Handle(GetListByDynamicUserProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListByDynamicAsync(
                  index: request.PageRequest.Page,
                  size: request.PageRequest.PageSize,
                  dynamic:request.Dynamic,
                  include: x => x.Include(up => up.User));

                UserProfileListModel userProfileListModel = _mapper.Map<UserProfileListModel>(userProfiles);
                return userProfileListModel;
            }
        }
    }
}
