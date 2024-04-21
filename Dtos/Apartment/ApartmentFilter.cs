using HomeRenterService.Dtos.Image;
using System.ComponentModel.DataAnnotations;

namespace HomeRenterService.Dtos.Apartment
{
    public class ApartmentSearch
    {
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative integer.")]
        public int? MinPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative integer.")]
        public int? MaxPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Size must be a non-negative integer.")]
        public int? MinSize { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Size must be a non-negative integer.")]
        public int? MaxSize { get; set; }

        public DateTime? Date { get; set; }

        // You can add custom validation attributes for PriceRange and SizeRange formats
    }
}
