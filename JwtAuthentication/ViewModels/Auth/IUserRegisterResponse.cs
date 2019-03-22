using JwtAuthentication.DTO.Usuario;
using JwtAuthentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels.Auth
{
    public interface IUserRegisterResponse
    {
        bool Succeded { get; set; }
        List<string> Message { get; set; }
    }
}
