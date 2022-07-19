

namespace RestaurantWebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public string OrderItem { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int Cost { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}