using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class FundRequest
    {
        public int FundRequestID { get; set; }
        public byte Grade { get; set; }
        public decimal Amount { get; set; }
        public string Motivation { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int StudentID { get; set; }
        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string DocumentStatus { get; set; }
    }


}
