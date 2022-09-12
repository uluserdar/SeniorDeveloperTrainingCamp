using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
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
    }
}
