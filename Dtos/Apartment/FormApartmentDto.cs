using MyRent.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyRent.Dtos.Apartment
{
    public class FormApartmentDto
    {
        
        [Required]
        public int Area { get; set; }
        [Required]
        public string Contact_No { get; set; } = string.Empty;
        public string noRomms { get; set; }= string.Empty;
        [Required]
        public string noToilets { get; set; }=string.Empty;

        [Required]
        public int totalCost { get; set; }
        [Required]
        public int Advance { get; set; }
        [Required]
        public string detials { get; set; } = string.Empty;
        
        //public DateOnly availableDate { get; set; }

        public IFormFileCollection Images { get; set; }

    }
}
