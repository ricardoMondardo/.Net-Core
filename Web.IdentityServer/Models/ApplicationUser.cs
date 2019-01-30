using Microsoft.AspNetCore.Identity;

namespace Web.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
