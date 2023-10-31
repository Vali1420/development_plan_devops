using System.ComponentModel.DataAnnotations;

namespace CarBillingApp.Models
{
    public class AddBillModel
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string VIN { get; set; }
        public string CustomerInformations { get; set; }
    }
}
