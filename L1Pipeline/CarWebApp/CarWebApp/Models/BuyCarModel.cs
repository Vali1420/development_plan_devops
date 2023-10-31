using System.ComponentModel.DataAnnotations;

namespace CarWebApp.Models
{
    public class BuyCarModel
    {
        [Required]
        public string VIN { get; set; }
    }
}
