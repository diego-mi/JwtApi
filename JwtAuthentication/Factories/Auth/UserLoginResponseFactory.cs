using JwtAuthentication.ViewModels.Auth;

namespace JwtAuthentication.Factories.Auth
{
    public static class UserLoginResponseFactory
    {
        public static UserLoginResponse LoginWithUserNotFound()
        {
            return new UserLoginResponse
            {
                LoggedIn = false,
                Message = "Usuário não existe",
            };
        }

        public static UserLoginResponse LoginWithWrongPassword()
        {
            return new UserLoginResponse
            {
                LoggedIn = false,
                Message = "Usuário e/ou senha inválidos!"
            };
        }

        public static UserLoginResponse LoginWithUserAndPassworValid(string Token)
        {
            return new UserLoginResponse
            {
                LoggedIn = true,
                Token = Token
            };
        }

        public static UserLoginResponse LoginWithServerError(string Message)
        {
            return new UserLoginResponse
            {
                LoggedIn = false,
                Token = Message
            };
        }
    }
}
