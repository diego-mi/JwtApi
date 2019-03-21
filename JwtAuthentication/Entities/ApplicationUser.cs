using Microsoft.AspNetCore.Identity;

namespace JwtAuthentication.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { set; get; }
    }
}
