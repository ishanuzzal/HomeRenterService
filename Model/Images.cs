using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRent.Model
{
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public DateTime uploadDate { get; set; }
        [Required]
        public string path { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public string ApartmentId { get; set; }
        public Apartment Apartment { get; set; }


    }
}
