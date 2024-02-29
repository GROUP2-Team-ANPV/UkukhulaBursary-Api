using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BBDFund
    {
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal RemainingBudget { get; set; }
    }
}
