using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<RegisteredUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthenticationBusinessRule _authenticationBusinessRule;

            public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, AuthenticationBusinessRule authenticationBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authenticationBusinessRule = authenticationBusinessRule;
            }

            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Email == request.Email);
                _authenticationBusinessRule.CheckIfRegisteredUser(user);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
                User mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;

                User addedUser = await _userRepository.AddAsync(user);
                RegisteredUserDto registeredUserDto=_mapper.Map<RegisteredUserDto>(addedUser);
                return registeredUserDto;
            }
        }
    }
}
