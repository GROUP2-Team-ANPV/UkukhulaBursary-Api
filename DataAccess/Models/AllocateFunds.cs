using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AllocateFunds
    {
        [Required(ErrorMessage = "University ID is required.")]
        public int UniversityID { get; set; }

        [Required(ErrorMessage = "Allocated amount is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Allocated amount must be a non-negative value.")]
        public int AllocatedAmount { get; set; }
    }
}
