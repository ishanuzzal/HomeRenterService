using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRent.Model
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]

        public string PhoneNo { get; set; }
        public string Address { get; set; } = string.Empty;

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Apartment> apartments { get; set; }


    }
}
