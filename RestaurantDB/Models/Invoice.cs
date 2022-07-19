namespace RestaurantWebApp.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int total { get; set; }
        public int OrderNumber { get; set; }
        public Order Order { get; set; }
    }
}