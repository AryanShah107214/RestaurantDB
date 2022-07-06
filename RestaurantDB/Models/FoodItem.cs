namespace RestaurantWebApp.Models
{
    public class FoodItem
    {
        public int FoodItemID { get; set; }
        public string FoodName { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}