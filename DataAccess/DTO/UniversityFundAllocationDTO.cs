using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class UniversityFundAllocationDTO
    {        
        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a non-negative value.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Balance is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a non-negative value.")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }
    }
}
