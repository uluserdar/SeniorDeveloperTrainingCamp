using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { nameof(GetByIdUserQuery) };

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthenticationBusinessRule _authenticationBusinessRule;

            public GetByIdUserQueryHandler(IMapper mapper, IUserRepository userRepository, AuthenticationBusinessRule authenticationBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authenticationBusinessRule = authenticationBusinessRule;
            }

            public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Id == request.Id);
                _authenticationBusinessRule.CheckIfExistsUser(user);

                UserGetByIdDto getUserByIdDto = _mapper.Map<UserGetByIdDto>(user);

                return getUserByIdDto;
            }
        }
    }
}
