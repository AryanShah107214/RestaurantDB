using System.ComponentModel.DataAnnotations;

namespace RestaurantDB.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(15, ErrorMessage = "Last Name must not exceed 15 characters")]

        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(15, ErrorMessage = "First Name must not exceed 15 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Mobile Number")]
        [MinLength(9, ErrorMessage = "Please enter a valid phone number")]//if user enters a phone number without 0 at the front, it should still be valid i.e. 272222222
        [MaxLength(10, ErrorMessage = "Please enter a valid phone number")] //if user enters a phone number with +64 at the front, it should still be valid i.e. 0272222222
        public uint PhoneNumber { get; set; }
    }
}