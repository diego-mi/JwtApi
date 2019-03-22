using JwtAuthentication.DTO.Usuario;
using JwtAuthentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels.Auth
{
    public class UserRegisterResponse : IUserRegisterResponse
    {
        public UserRegisterResponse()
        {
            Message = new List<string>();
        }


        public bool Succeded { get; set; }
        public List<string> Message { get; set; }
    }
}
