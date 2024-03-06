using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DataAccess.Models
{
    public class ContactDetails
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(13, ErrorMessage = "Phone number cannot exceed 13 characters.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^(\+?27|0)?[1678][0-9]{8}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }



    
    }
}
