using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public string ApartmentId { get; set; }
        [ForeignKey("ApartmentId")]

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Apartment Apartment { get; set; }


    }
}
