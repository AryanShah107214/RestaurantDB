namespace RestaurantWebApp.Models
{
    public class FoodMenu
    {
        public int FoodMenuID { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int FoodItemID { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}