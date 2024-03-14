using System.ComponentModel.DataAnnotations;

namespace HomeRenterService.Dtos.Image
{
    public class ImageDto
    {
        [Required]
        public DateTime uploadDate { get; set; }
        [Required]
        public string path { get; set; } = string.Empty;
    }
}
