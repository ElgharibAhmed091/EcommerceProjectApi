using Microsoft.AspNetCore.Identity;

namespace EcommerceProAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
  
}
