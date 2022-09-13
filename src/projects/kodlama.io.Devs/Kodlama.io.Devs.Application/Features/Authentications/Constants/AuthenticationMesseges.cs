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

        public static string CheckIfActiveUserErrorMessage => "Active user not found";

        public static string CheckIfPasswordIsVerifyErrorMessage => "Password error";

        public static string CheckIfRegisteredUserErrorMessage => "There is a registered user with this email";
    }
}
