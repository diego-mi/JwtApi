﻿using System.ComponentModel.DataAnnotations;

namespace JwtAuthentication.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
