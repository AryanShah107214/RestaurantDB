

using System.ComponentModel.DataAnnotations;

namespace RestaurantDB.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Order Item")]
        public string OrderItem { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Display(Name = "Spice Level")]
        public string SpiceLevel { get; set; }
        
        [Required]
        public double Cost { get; set; } 
        
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}