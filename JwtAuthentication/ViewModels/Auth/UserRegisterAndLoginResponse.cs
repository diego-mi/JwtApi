using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels.Auth
{
    public class UserRegisterAndLoginResponse : UserRegisterResponse, IUserRegisterResponse
    {
        public UserLoginResponse UserLoginResponse { get; set; }

        public UserRegisterAndLoginResponse(IUserRegisterResponse userRegisterResponse, UserLoginResponse userLoginResponse)
        {
            Succeded = userRegisterResponse.Succeded;
            Message = userRegisterResponse.Message;
            UserLoginResponse = userLoginResponse;
        }
    }
}
