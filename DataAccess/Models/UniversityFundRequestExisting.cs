
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UniversityFundRequestExisting
    {

        int ID { get; set; }
        [Required(ErrorMessage = "University name is required.")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        public string Province { get; set; }

        public string Comment { get; set; }

        DateTime DateCreated { get; set; }

        public UniversityFundRequestExisting(int id, string universityName, decimal amount, string status, string province, string comment, DateTime dateCreated)
        {
            ID = id;
            UniversityName = universityName;
            Amount = amount;
            Status = status;
            Province = province;
            Comment = comment;
            DateCreated = dateCreated;
        }

        public int getID() => ID;
        public string getUniversityName() => UniversityName;
        public decimal getAmount() => Amount;
        public string getStatus() => Status;
        public string getProvince() => Province;
        public string getComment() => Comment;
        public DateTime getDateCreated() => DateCreated;

    }
}

