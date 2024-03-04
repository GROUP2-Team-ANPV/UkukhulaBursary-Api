using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class BBDFund
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Number of funded universities is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of funded universities must be a non-negative value.")]
        public int FundedUniversities { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a non-negative value.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Amount used is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount used must be a non-negative value.")]
        public decimal RemainingBudget { get; set; }
    }

}
