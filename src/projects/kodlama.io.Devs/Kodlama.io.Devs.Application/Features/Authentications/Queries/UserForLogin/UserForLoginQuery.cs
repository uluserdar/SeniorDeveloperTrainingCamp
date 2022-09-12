using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.UserForLogin
{
    public class UserForLoginQuery:IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class UserForLoginQueryHandler : IRequestHandler<UserForLoginQuery, AccessToken>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthenticationBusinessRule _authBusinessRule;

            public UserForLoginQueryHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, AuthenticationBusinessRule authBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _authBusinessRule = authBusinessRule;
            }

            public async Task<AccessToken> Handle(UserForLoginQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.Email && u.Status);
                _authBusinessRule.ActiveUserExistControl(user);
                _authBusinessRule.ActiveUserPasswordVerify(request.Password, user.PasswordHash, user.PasswordSalt);

                List<OperationClaim> claims = _userRepository.GetClaims(user.Id).ToList();

                var accessToken = _tokenHelper.CreateToken(user, claims);

                return accessToken;
            }
        }
    }
}
