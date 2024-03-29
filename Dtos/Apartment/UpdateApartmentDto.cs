﻿using System.ComponentModel.DataAnnotations;

namespace HomeRenterService.Dtos.Apartment
{
    public class UpdateApartmentDto
    {
        [Required]
        public int Size { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
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

        public DateTime AvailableDate { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
