using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest<DeletedUserDto>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>,ISecuredRequest
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthenticationBusinessRule _authenticationBusinessRule;
            public string[] Roles => new[] { "User.Delete" };

            public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository, AuthenticationBusinessRule authenticationBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authenticationBusinessRule = authenticationBusinessRule;
            }

            public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Id == request.Id,enableTracking:false);
                _authenticationBusinessRule.CheckIfExistsUser(user);

                User mappedUser = _mapper.Map<User>(request);
                User deletedUser = await _userRepository.DeleteAsync(mappedUser);
                DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);

                return deletedUserDto;
            }
        }
    }
}
