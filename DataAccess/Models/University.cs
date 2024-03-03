using System.Dynamic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class University
    {
        public int ID { get; set; }        
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Province ID is required.")]
        public int ProvinceID { get; set; }

        public University(string name, int provinceID)
        {
            Name = name;
            ProvinceID = provinceID;
        }
        public University(int _id, string _name, int _provinceID)
        {
            ID = _id;
            Name = _name;
            ProvinceID = _provinceID;

        }

        public int GetID() => ID;
        public string GetName() => Name;
        public int GetProvinceID() => ProvinceID;



    }
}
