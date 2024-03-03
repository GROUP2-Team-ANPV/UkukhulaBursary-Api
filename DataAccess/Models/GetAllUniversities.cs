using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class GetAllUniversities
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "University name is required.")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "Province name is required.")]
        public string ProvinceName { get; set; }
        public int Students {  get; set; }
        public int HODS { get; set; }

        [Required(ErrorMessage = "Contact person is required.")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
