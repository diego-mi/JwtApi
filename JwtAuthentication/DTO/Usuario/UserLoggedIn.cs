using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.DTO.Usuario
{
    public class UserLoggedIn
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
