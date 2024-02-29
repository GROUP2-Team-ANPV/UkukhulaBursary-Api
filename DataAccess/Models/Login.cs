using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }

    }
}
