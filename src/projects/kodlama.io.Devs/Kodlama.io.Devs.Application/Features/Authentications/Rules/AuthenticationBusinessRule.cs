using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Constants;

namespace Kodlama.io.Devs.Application.Features.Authentications.Rules
{
    public class AuthenticationBusinessRule
    {

        public void CheckIfActiveUser(User user)
        {
            if (user == null) throw new BusinessException(AuthenticationMesseges.CheckIfActiveUserErrorMessage);
        }

        public void CheckIfPasswordIsVerify(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)) throw new BusinessException(AuthenticationMesseges.CheckIfPasswordIsVerifyErrorMessage);
        }

        public void CheckIfExistsUser(User user)
        {
            if(user==null) throw new BusinessException(AuthenticationMesseges.CheckIfExistsUserErrorMessage);
        }

        public void CheckIfRegisteredUser(User user)
        {
            if(user != null) throw new BusinessException(AuthenticationMesseges.CheckIfRegisteredUserErrorMessage);
        }
    }
}
