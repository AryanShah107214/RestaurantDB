using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDB.Models
{
    public class FoodMenu
    {
        public int FoodMenuID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        [MaxLength(20,ErrorMessage = "Item name exceeds limit")]
        public string FoodName { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        
        [Required]
        [MinLength(5,ErrorMessage = "Enter valid category")]//shortest category name is 5 characters i.e. Mains
        [MaxLength(7,ErrorMessage = "Enter valid category")]//longest category name is 7 characters i.e. deserts, entrees
        public string Category { get; set; }

        [NotMapped]
        [Display(Name = "Upload photo of item")]
        [Required]
        public IFormFile FoodPhoto { get; set; }

        public string PhotoPath { get; set; }


    }
}