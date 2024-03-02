using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UpdateFundRequest
    {

        public String FirstName {get;set;}
        public String LastName{get;set;}

        public int Age{get;set;}

        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Grade { get; set; }
        public decimal Amount { get; set; }
        public string Motivation { get; set; }
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
        public string ApplicationStatus { get; set; }

    }
}