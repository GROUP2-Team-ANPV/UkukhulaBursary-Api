using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class StudentFundRequest
    {

       
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

        [Required(ErrorMessage = "Gender ID is required.")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "Race ID is required.")]
        public int RaceID { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [Range(1, 100, ErrorMessage = "Grade must be between 1 and 100 (representing a percentage).")]
        public byte Grade { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Motivation is required.")]
        public string Motivation { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "University ID is required.")]
        public int UniversityID { get; set; }
}
}
