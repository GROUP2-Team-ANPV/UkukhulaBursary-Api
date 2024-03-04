using System.ComponentModel.DataAnnotations;


namespace DataAccess.DTO
{
public class StudentDTO
{
    public int StudentID { get; set; }
        public int RequestID { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(120, ErrorMessage = "First name cannot exceed 120 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(120, ErrorMessage = "Last name cannot exceed 120 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ID number is required.")]
        [StringLength(13, ErrorMessage = "ID number must be 13 characters.")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Race is required.")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
         [RegularExpression(@"^(\+?27|0)?[1678][0-9]{8}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Application status is required.")]
        public string ApplicationStatus { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Motivation is required.")]
        public string Motivation { get; set; }

    public string Comment { get; set; }
    public DateTime ApplicationDate { get; set; }
}

}