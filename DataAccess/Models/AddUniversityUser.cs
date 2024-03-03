using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AddUniversityUser
    {
 
        public int UniversityID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        public int DepartmentID { get; set; }
    }
}
