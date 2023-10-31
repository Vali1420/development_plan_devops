using System.ComponentModel.DataAnnotations;

namespace CarWebApp.Models
{
    public class AddCarModel
    {
        [Required]
        public string VIN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
