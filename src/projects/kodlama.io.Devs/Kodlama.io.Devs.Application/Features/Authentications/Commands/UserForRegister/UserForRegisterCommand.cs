using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UserForRegister
{
    public class UserForRegisterCommand : IRequest<UserForRegisterDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class UserForRegisterCommandHandler : IRequestHandler<UserForRegisterCommand, UserForRegisterDto>
        {

            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthenticationBusinessRule _authenticationBusinessRule;

            public UserForRegisterCommandHandler(IMapper mapper, IUserRepository userRepository, AuthenticationBusinessRule authenticationBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authenticationBusinessRule = authenticationBusinessRule;
            }

            public async Task<UserForRegisterDto> Handle(UserForRegisterCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.Email);
                _authenticationBusinessRule.UserCanNotBeDublicatedWhenInserted(user);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

                User mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.PasswordHash = passwordHash;

                User addedUser = await _userRepository.AddAsync(mappedUser);
                UserForRegisterDto userForRegisterDto = _mapper.Map<UserForRegisterDto>(addedUser);
                userForRegisterDto.Password = request.Password;

                return userForRegisterDto;
            }
        }
    }
}
