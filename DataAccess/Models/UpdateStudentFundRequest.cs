using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UpdateStudentFundRequest
    {
        [Required]
        public byte Grade { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }
    }
}
