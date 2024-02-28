using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UniversityFundAllocationDTO
    {
        public decimal TotalAmount { get; set; }
        public decimal Balance { get; set;}
        public int Year {  get; set;}
    }
}
