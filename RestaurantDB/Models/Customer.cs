using System.ComponentModel.DataAnnotations;

namespace RestaurantDB.Models
{
    public class Customer
    {
        //applied validation like making the field required, maximum and minimum lengths and displaying the name differently than the 

        public int CustomerID { get; set; }

        
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(15,ErrorMessage = "Last Name must not exceed 15 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(15, ErrorMessage = "First Name must not exceed 15 characters")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [Range(0201111111,uint.MaxValue, ErrorMessage = "Please enter a valid mobile number")]
        public uint PhoneNumber { get; set; }
    }
}