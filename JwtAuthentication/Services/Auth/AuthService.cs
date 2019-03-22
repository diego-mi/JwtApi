using JwtAuthentication.DTO.Usuario;
using JwtAuthentication.Entities;
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
            UserLoginResponse userLoginResponse = new UserLoginResponse
            {
                Model = model
            };

            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                userLoginResponse.User = new UserLoginViewModel(user);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    userLoginResponse.Token = GetToken();
                    userLoginResponse.LoggedIn = true;

                    return userLoginResponse;
                }

                userLoginResponse.LoggedIn = false;
                userLoginResponse.Message = "Usuário e/ou senha inválidos!";

                return userLoginResponse;
            }
            catch (Exception exception)
            {
                userLoginResponse.LoggedIn = false;
                userLoginResponse.Message = exception.Message;

                return userLoginResponse;
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
