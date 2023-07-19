using Microsoft.AspNetCore.Identity;

namespace newLive.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
    }
}
