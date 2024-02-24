using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class StudentFundRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderID { get; set; }
        public int RaceID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte Grade { get; set; }
        public decimal Amount { get; set; }
        public string Motivation { get; set; }
        public int DepartmentID { get; set; }
        public int UniversityID { get; set; }
    }
}
