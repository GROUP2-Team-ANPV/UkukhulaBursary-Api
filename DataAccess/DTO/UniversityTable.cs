using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UniversityTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public int ContactPerson{get; set;}
    }
}
