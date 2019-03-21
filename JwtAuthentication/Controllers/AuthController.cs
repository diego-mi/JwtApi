using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtAuthentication.Entities;
using JwtAuthentication.Services.Auth;
using JwtAuthentication.Services.Configuracoes;
using JwtAuthentication.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthentication.Controllers
{
    [Route("api/v1/auth")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, AuthService authService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
                return Ok(new { Username = user.UserName });
            } catch (Exception exception)
            {
                return BadRequest(new { message = "Teste: " + exception.Message });
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                UserLoginResponse userLoginResponse = await _authService.LoginAsync(model);

                return Ok(userLoginResponse);
            }
            catch (Exception exception)
            {
                return BadRequest(new { LoggedIn = false, Message = exception.Message });
            }
        }
    }

}