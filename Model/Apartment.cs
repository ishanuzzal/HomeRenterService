using Microsoft.EntityFrameworkCore;
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
        public int Size { get; set; }
        [Required]
        public string Contact_No { get; set; }
        public string noRomms { get; set; }
        [Required]
        public string noToilets { get; set; }
        [Required]
        public DateTime availableDate { get; set; }
        [Required]
        public int totalCost { get; set; }
        [Required]
        public int Advance {  get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string detials { get; set; }
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Owner Owner { get; set; }

        public List<Images> images { get; set; }
    }
}
