using System.ComponentModel.DataAnnotations;

namespace RestaurantDB.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        public uint PhoneNumber { get; set; }
    }
}