using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.Entity
{
    public class UniversityAmount
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "University name is required.")]
        [StringLength(100, ErrorMessage = "University name must be at most 100 characters.")]
        public string UniversityName { get; set; }
    }
}
