using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AllocationDetails
    {   

        [Required(ErrorMessage = "University name is required.")]
        public string University { get; set; }

        [Required(ErrorMessage = "Province name is required.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Budget amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a non-negative value.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Date allocated is required.")]
        [DataType(DataType.Date)]
        public DateTime DateAllocated { get; set; }

        [Required(ErrorMessage = "Total allocated amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total allocated must be a non-negative value.")]
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

 
