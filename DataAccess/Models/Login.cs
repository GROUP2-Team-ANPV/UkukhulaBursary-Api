using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email {  get; set; }

    }
}
