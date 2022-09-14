using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UpdateUser
{
    public class UpdateUserCommand:IRequest<UpdatedUserDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string[] Roles => new[] { nameof(UpdateUserCommand) };

        public class UpdateUserQueryHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly AuthenticationBusinessRule _authenticationBusinessRule;

            public UpdateUserQueryHandler(IMapper mapper, IUserRepository userRepository, AuthenticationBusinessRule authenticationBusinessRule)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authenticationBusinessRule = authenticationBusinessRule;
            }

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Id == request.Id,enableTracking:false);
                _authenticationBusinessRule.CheckIfExistsUser(user);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
                User mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;

                User updatedUser = await _userRepository.UpdateAsync(mappedUser);
                UpdatedUserDto updatedUserDto=_mapper.Map<UpdatedUserDto>(updatedUser);

                return updatedUserDto;
            }
        }
    }
}
