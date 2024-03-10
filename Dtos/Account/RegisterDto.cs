using System.ComponentModel.DataAnnotations;

namespace MyRent.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; } = "01991111111";


        public string Address { get; set; } = "Dhaka";

       
    }
}
