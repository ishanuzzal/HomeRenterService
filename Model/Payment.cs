using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRent.Model
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public DateTime? paymentTime { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
        
        [Required]
        public string RenterId { get; set; }
        [ForeignKey("RenterId")]
        public Renter Renter { get; set; }
        [Required]
        public string ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        [Required]
        
        public string OwnerId { get; set; }
        [ForeignKey("ownerId")]
        public Owner owner { get; set; }


    }
}
