using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UniversityFundRequest
    {
        int ID { get; set; }
        int UniversityID { get; set; }

        [Required(ErrorMessage = "Date created is required.")]
        DateTime DateCreated { get; set; }

        decimal Amount { get; set; }
        [Required(ErrorMessage = "Status ID is required.")]
        public string StatusID { get; set; }
        string Comment { get; set; }


        public UniversityFundRequest(int universityID, DateTime dateCreated, decimal amount, string statusID, string comment)
        {
            UniversityID = universityID;
            DateCreated = dateCreated;
            Amount = amount;
            StatusID = statusID;
            Comment = comment;
        }


       public int getUniversityID()=> UniversityID;
       
        public DateTime getDateCreated()=> DateCreated;
        public decimal getAmount()=> Amount;
        public string getStatusID()=> StatusID;
        public string getComment()=> Comment;

    }
}
