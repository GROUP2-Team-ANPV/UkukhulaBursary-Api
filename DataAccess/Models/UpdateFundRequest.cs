using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UpdateFundRequest
    {


        
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "ID number is required.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be 13 characters.")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Race is required.")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [Range(1, 100, ErrorMessage = "Grade must be between 1 and 100 (representing a percentage).")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Motivation is required.")]
        public string Motivation { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Application status is required.")]
        public string ApplicationStatus { get; set; }


    }
}