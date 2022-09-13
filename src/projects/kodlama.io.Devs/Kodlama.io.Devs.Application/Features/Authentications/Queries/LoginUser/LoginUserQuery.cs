using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Queries.LoginUser
{
    public class LoginUserQuery:IRequest<LoggedUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoggedUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthenticationBusinessRule _authBusinessRule;

            public LoginUserQueryHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, AuthenticationBusinessRule authBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _authBusinessRule = authBusinessRule;
            }

            public async Task<LoggedUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.Email && u.Status);
                _authBusinessRule.CheckIfActiveUser(user);
                _authBusinessRule.CheckIfPasswordIsVerify(request.Password, user.PasswordHash, user.PasswordSalt);

                List<OperationClaim> claims = _userRepository.GetClaims(user.Id).ToList();

                var accessToken = _tokenHelper.CreateToken(user, claims);

                LoggedUserDto loggedUserDto=_mapper.Map<LoggedUserDto>(request);
                loggedUserDto.Token = accessToken.Token;
                loggedUserDto.Expiration = accessToken.Expiration;

                return loggedUserDto;
            }
        }
    }
}
