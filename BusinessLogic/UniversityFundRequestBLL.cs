
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UniversityFundRequestBLL
    {
        private readonly UniversityDAL _repository;

        public UniversityFundRequestBLL(UniversityDAL repository)
        {
            _repository = repository;
        }

        public List<University> GetUniversities()
        {
            return _repository.GetUniversities();
        }

        public void Create(UniversityFundRequest newRequest)
        {
            if (newRequest != null)
                try
                {
                    _repository.SaveUniversityFundRequest(newRequest);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error creating university fund request", ex);
                }
            else
                throw new ArgumentNullException(nameof(newRequest));
        }

        public void Allocate()
        {
            try
            {
                _repository.allocate();
            }
            catch (Exception ex)
            {
                throw new Exception("Error allocating funds", ex);
            }
        }

        

    }
}