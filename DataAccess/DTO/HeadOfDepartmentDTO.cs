using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class HeadOfDepartmentDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(120, ErrorMessage = "First name cannot exceed 120 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(120, ErrorMessage = "Last name cannot exceed 120 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(255, ErrorMessage = "Department name cannot exceed 255 characters.")]
        public string DepartmentName { get; set; }
       
    }
}
