using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UniversityRequest(string university, string province, decimal amount, string status, DateTime dateCreated, string comment)
    {
        

        public string University { get; set; } = university;
        public string Province { get; set; } = province;
        public decimal Amount { get; set; } = amount;
        public string Status { get; set; } = status;
        public DateTime DateCreated { get; set; } = dateCreated;
        public string Comment { get; set; } = comment;
    }
}
