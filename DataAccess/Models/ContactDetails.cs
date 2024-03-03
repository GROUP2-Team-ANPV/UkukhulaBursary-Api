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
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(13, ErrorMessage = "Phone number cannot exceed 13 characters.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }



    
    }
}
