using HomeRenterService.Dtos.Image;
using System.ComponentModel.DataAnnotations;

namespace HomeRenterService.Dtos.Apartment
{
    public class AllApartmentDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public int size { get; set; }
        [Required]
        public string Address { get; set; }
        public string Contact_No { get; set; } = string.Empty;
        public string noRomms { get; set; } = string.Empty;
        [Required]
        public string noToilets { get; set; } = string.Empty;

        [Required]
        public int totalCost { get; set; }
        [Required]
        public int Advance { get; set; }
        [Required]
        public string detials { get; set; } = string.Empty;

        [Required]
        public DateTime availableDate { get; set; }

        [Required]
        public List<ImageDto> Images { get; set; }
    }
}
