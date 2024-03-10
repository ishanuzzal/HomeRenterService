using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyRent.Model
{
    public class AppUser: IdentityUser
    {
        
        [Required]
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
