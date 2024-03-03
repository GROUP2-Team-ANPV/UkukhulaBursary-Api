
using System.ComponentModel.DataAnnotations;
namespace DataAccess.Models
{
    public class UniversityFundAllocation
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a non-negative value.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Date allocated is required.")]
        [DataType(DataType.DateTime)]
        public DateTime DateAllocated { get; set; }

        [Required(ErrorMessage = "University ID is required.")]
        public int UniversityID { get; set; }

        [Required(ErrorMessage = "BBD Allocation ID is required.")]
        public int BBDAllocationID { get; set; }

        public UniversityFundAllocation(decimal budget, DateTime dateAllocated, int universityID, int bbdAllocationID)
        {
            Budget = budget;
            DateAllocated = dateAllocated;
            UniversityID = universityID;
            BBDAllocationID = bbdAllocationID;
        }

        public void save()
        {
            //new DBManager().SaveUniversityFundAllocation(this);

        }

        //gettes for all the attributes
        public decimal getBudget() => Budget;

        public DateTime getDateAllocated() => DateAllocated;

        public int getUniversityID() => UniversityID;

        public int getBBDAllocationID() => BBDAllocationID;

        public int getID() => ID;


    }
}
