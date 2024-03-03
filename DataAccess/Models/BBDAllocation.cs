
using System.ComponentModel.DataAnnotations;
namespace DataAccess.Models
{
    public class BBDAllocation
    {


        int ID { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a non-negative value.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Date created is required.")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public BBDAllocation(int _id, decimal _budget, DateTime _dateCreated)
        {
            ID = _id;
            Budget = _budget;
            DateCreated = _dateCreated;
        }
        public BBDAllocation(decimal budget, DateTime dateCreated)
        {
            Budget = budget;
            DateCreated = dateCreated;
        }

        public decimal getBudget() => Budget;

        public int getID() => ID;

        public DateTime getDate() => DateCreated;



    }
}
