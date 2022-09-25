using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp.Models
{
    public class FoodMenu
    {
        public int FoodMenuID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string FoodName { get; set; }

        [Required]
        public double Price { get; set; }
        
        [Required]
        public string Category { get; set; }
    }
}