using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Constants
{
    public static class AuthenticationMesseges
    {
        public static string UserCanNotBeDublicatedWhenInsertedMessage => "Email exists.";

        public static string ActiveUserExistsControlMessage => "Active user not found";

        public static string PasswordErrorMessage => "Password error";
    }
}
