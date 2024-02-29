using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AllocationDetails
    {   

        public string University { get; set; }
        public string Province { get; set; }
        public decimal Budget { get; set; }
        public DateTime DateAllocated { get; set; }
        public decimal TotalAllocated { get; set; }

    public AllocationDetails(string university, string province, decimal budget, DateTime dateAllocated, decimal totalAllocated)
    {
        University = university;
        Province = province;
        Budget = budget;
        DateAllocated = dateAllocated;
        TotalAllocated = totalAllocated;
    }
}
    }

 
