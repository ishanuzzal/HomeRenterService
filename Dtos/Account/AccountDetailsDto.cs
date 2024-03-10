using System.ComponentModel.DataAnnotations;

namespace MyRent.Dtos.Account
{
    public class AccountDetailsDto
    {
        
        public string UserName { get; set; } = string.Empty;
        
        public string FullName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;


        public string Address { get; set; } = string.Empty;
    }
}
