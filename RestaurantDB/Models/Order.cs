

using System.ComponentModel.DataAnnotations;

namespace RestaurantDB.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Order Item")]
        [MaxLength(20, ErrorMessage = "Item name exceeds limit")]
        public string OrderItem { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Enter a valid quantity - between 1 and 99")]

        public int Quantity { get; set; }
        
        [Display(Name = "Spice Level")]
        [MaxLength (15,ErrorMessage ="Enter a valid spice level (Mild,Mild-Medium,Medium,Medium-Hot or Hot")]
        public string SpiceLevel { get; set; }
        
        [Required]
        public double Cost { get; set; } 
        
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}