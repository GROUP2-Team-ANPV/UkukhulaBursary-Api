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
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^(\+?27|0)?[1678][0-9]{8}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "DepartmentID is required")]
        public int DepartmentID { get; set; }
}
