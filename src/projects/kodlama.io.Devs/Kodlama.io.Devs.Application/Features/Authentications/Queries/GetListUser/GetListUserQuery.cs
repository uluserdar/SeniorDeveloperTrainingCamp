using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.GetListUser
{
    public class GetListUserQuery:IRequest<UserListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { "User.Read" };

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public GetListUserQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                UserListModel getListUserModel=_mapper.Map<UserListModel>(users);

                return getListUserModel;
            }
        }
    }
}
