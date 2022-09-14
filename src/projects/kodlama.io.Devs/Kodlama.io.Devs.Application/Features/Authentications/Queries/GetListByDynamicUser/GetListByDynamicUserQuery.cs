using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.GetListByDynamicUser
{
    public class GetListByDynamicUserQuery:IRequest<UserListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
        public string[] Roles => new[] { nameof(GetListByDynamicUserQuery) };

        public class GetListByDynamicUserQueryHandler : IRequestHandler<GetListByDynamicUserQuery, UserListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public GetListByDynamicUserQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserListModel> Handle(GetListByDynamicUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListByDynamicAsync(dynamic: request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                UserListModel userListModel = _mapper.Map<UserListModel>(users);

                return userListModel;
            }
        }
    }
}
