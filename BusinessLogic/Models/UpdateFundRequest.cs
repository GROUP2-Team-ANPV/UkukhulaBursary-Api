using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class UpdateFundRequest
    {
        public byte Grade { get; set; }
        public decimal Amount { get; set; }
        public string Motivation { get; set; }
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
    }
}