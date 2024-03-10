using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRent.Model
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public string Contact_No { get; set; }
        public string noRomms { get; set; }
        [Required]
        public string noToilets { get; set; }
        [Required]
        public DateOnly availableDate { get; set; }
        [Required]
        public int totalCost { get; set; }
        [Required]
        public int Advance {  get; set; }
        [Required]
        public string detials { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public Owner Owner { get; set; }

        public List<Images> images { get; set; }
    }
}
