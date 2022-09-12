using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Rules
{
    public class AuthenticationBusinessRule
    {
        public void UserCanNotBeDublicatedWhenInserted(User user)
        {
            if (user != null) throw new BusinessException(AuthenticationMesseges.UserCanNotBeDublicatedWhenInsertedMessage);
        }

        public void ActiveUserExistControl(User user)
        {
            if (user == null) throw new BusinessException(AuthenticationMesseges.ActiveUserExistsControlMessage);
        }

        public void ActiveUserPasswordVerify(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)) throw new BusinessException(AuthenticationMesseges.PasswordErrorMessage);
        }
    }
}
