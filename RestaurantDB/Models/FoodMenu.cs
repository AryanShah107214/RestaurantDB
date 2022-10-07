using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApp.Models
{
    public class FoodMenu
    {
        public int FoodMenuID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string FoodName { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        
        [Required]
        public string Category { get; set; }

        [NotMapped]
        [Display(Name = "Upload photo of item")]
        [Required]
        public IFormFile FoodPhoto { get; set; }

        public string PhotoPath { get; set; }


    }
}