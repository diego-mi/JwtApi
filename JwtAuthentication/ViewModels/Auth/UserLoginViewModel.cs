using JwtAuthentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels.Auth
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Username = user.UserName;
            Email = user.Email;
        }

        public string Id { get; }
        public string Username { get; }
        public string Email { get; }
    }
}
