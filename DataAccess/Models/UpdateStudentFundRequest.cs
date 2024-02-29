using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UpdateStudentFundRequest
    {
        [Required]
        public byte Grade { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
