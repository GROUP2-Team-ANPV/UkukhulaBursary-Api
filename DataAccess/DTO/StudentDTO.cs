using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Amount { get; set; }
        public string ApplicationStatus { get; set; }
    }

}
