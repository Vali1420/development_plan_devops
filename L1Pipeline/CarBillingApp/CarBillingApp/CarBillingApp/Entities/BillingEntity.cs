using System.ComponentModel.DataAnnotations;

namespace CarBillingApp.Entities
{
    public class BillingEntity
    {
        [Key]
        public string CustomerId { get; set; }
        public string VIN { get; set; }
        public DateTime PurchasedDateTime { get; set; }
        public string CustomerInformations { get; set; }
    }
}
