namespace DataAccess.Models;
using System.ComponentModel.DataAnnotations;

public class AddUniversityAndUser
{
        [Required(ErrorMessage = "UniversityName is required")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "ProvinceID is required")]
        public int ProvinceID { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "DepartmentID is required")]
        public int DepartmentID { get; set; }
}
