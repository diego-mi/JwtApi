using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels.Auth
{
    public class UserLoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public bool LoggedIn { get; set; }
    }
}
