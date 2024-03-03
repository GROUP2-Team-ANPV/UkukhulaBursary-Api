using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class FundRequest
    {
        public int FundRequestID { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
        public byte Grade { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }
        public string Motivation { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int StudentID { get; set; }
            [Required(ErrorMessage = "ID number is required.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be 13 digits long.")]
        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "University is required.")]
        public string University { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Race is required.")]
        public string Race { get; set; }

        [Required(ErrorMessage = "Document status is required.")]
        public string DocumentStatus { get; set; }
    }


}
