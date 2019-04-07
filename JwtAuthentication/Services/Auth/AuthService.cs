using JwtAuthentication.DTO.Usuario;
using JwtAuthentication.Entities;
using JwtAuthentication.Factories.Auth;
using JwtAuthentication.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Services.Auth
{
    public interface IAuthService
    {
        Task<UserLoginResponse> LoginAsync(LoginViewModel model);
        Task<UserRegisterResponse> RegisterAsync(RegisterViewModel model);

    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        #region Login

        public async Task<UserLoginResponse> LoginAsync(LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user == null)
                {
                    return UserLoginResponseFactory.LoginWithUserNotFound();
                }

                bool userAndPassworkIsCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

                if (userAndPassworkIsCorrect)
                {
                    return UserLoginResponseFactory.LoginWithUserAndPassworValid(GetToken());
                }

                return UserLoginResponseFactory.LoginWithWrongPassword();
            }
            catch (Exception exception)
            {
                return UserLoginResponseFactory.LoginWithServerError(exception.Message);
            }
        }

        private string GetToken()
        {
            var signinKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

            int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Site"],
              audience: _configuration["Jwt:Site"],
              expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion Login

        #region Register

        public async Task<UserRegisterResponse> RegisterAsync(RegisterViewModel model)
        {
            UserRegisterResponse userRegisterResponse = new UserRegisterResponse();

            try
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(applicationUser, model.Password);

                if (result.Succeeded)
                {
                    await AddRoleToUserAsync(applicationUser);
                    userRegisterResponse.Succeded = true;
                }
                else
                {
                    userRegisterResponse.Succeded = false;
                    foreach (var erro in result.Errors)
                    {
                        if (erro.Code == "DuplicateUserName")
                        {
                            userRegisterResponse.Message.Add("O email '" + applicationUser.UserName + "' já está em uso.");
                        }
                        else
                        {
                            userRegisterResponse.Message.Add("Erro: " + erro.Code + " - " + erro.Description);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                userRegisterResponse.Succeded = false;
                userRegisterResponse.Message.Add(exception.Message);
            }

            return userRegisterResponse;
        }

        private async Task AddRoleToUserAsync(ApplicationUser applicationUser)
        {
            await _userManager.AddToRoleAsync(applicationUser, "Customer");
        }

        #endregion Register
    }
}
