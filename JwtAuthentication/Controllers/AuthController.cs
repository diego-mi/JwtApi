using System;
using System.Collections.Generic;
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
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IAuthService authService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IUserRegisterResponse userRegisterResponse = await _authService.RegisterAsync(model);

                if (userRegisterResponse.Succeded)
                {
                    return Ok(userRegisterResponse);
                }

                return BadRequest(userRegisterResponse);
            }

            return BadRequest(model);
        }

        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                UserLoginResponse userLoginResponse = await _authService.LoginAsync(model);

                return Ok(userLoginResponse);
            }
            catch (Exception exception)
            {
                return BadRequest(
                    new UserLoginResponse()
                    {
                        LoggedIn = false,
                        Message = exception.Message
                    }
                );
            }
        }
    }

}