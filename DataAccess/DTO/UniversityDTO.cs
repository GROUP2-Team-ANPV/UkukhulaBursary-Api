using DataAccess.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
           #nullable enable
    public class UniversityDTO
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public List<UniversityFundAllocationDTO> FundAllocation { get; set; } = new List<UniversityFundAllocationDTO>();
        public List<HeadOfDepartmentDTO> HeadOfDepartment { get; set; } = new List<HeadOfDepartmentDTO>();
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }

    /*{ universityName: name,
  province: gauteng,
  contactPerson: {
    firstname,
    lastname,
    phone,
    email
  }
  students:{
    1:{
        firstname,
        lastname,
        phone,
        email,
        applicationstatus,
        amount,
        }
     2:{
        firstname,
        lastname,
        phone,
        email,
        applicationstatus,
        amount,
        }
    }
    HODs: {
         3: {
              firstname,
              lastname,
              department,
              phone,
              email
             }
          etc.
      }
}*/
}
