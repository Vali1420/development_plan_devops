namespace CarBillingApp.Models
{
    public class GetBillsModel
    {
        public string CustomerId { get; set; }
        public string VIN { get; set; }
        public DateTime PurchasedDateTime { get; set; }
        public string CustomerInformations { get; set; }
    }
}
