using HomeRenterService.Dtos.Image;
using System.ComponentModel.DataAnnotations;

namespace HomeRenterService.Dtos.Apartment
{
    public class ApartmentFilter
    {
        public int? Id { get; set; }
        public string? OwnerName { get; set; }
        public int? MinSize { get; set; }
        public int? MaxSize { get; set; }

        public string? Address { get; set; }
        public string? NoRomms { get; set; } 
        public string? NoToilets { get; set; } 
        public int? MinTotalCost { get; set; }

        public int? MaxTotalCost { get; set; }
        public DateTime? AvailableDate { get; set; }

    }
}
