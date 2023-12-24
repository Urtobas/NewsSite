using Microsoft.AspNetCore.Identity;

namespace NewsSite.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string RealUserName { get; set; }
    }
}
