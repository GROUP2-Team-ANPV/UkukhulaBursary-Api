using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class GetAllStudents
    {
        public int StudentID { get; set; }
       [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ID number is required.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be 13 characters long.")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 255, ErrorMessage = "Age must be between 0 and 255.")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Race is required.")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "University is required.")]
        public string University { get; set; }
    }
}
