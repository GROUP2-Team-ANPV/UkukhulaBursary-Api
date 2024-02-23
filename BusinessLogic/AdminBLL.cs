using DataAccess;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic

{
    public class AdminBLL(AdminDAL repository)
    {
        private readonly AdminDAL _repository = repository;

        public IEnumerable<UniversityRequest> GetAllUniversityRequests()
        {
            try
            {
                return _repository.GetAllUniversityFundRequests();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting university requests: {ex.Message}");
            }
        }

        public UniversityRequest UpdateUniversityRequest(int requestId, int StatusId)
        {
            try
            {
                return _repository.UpdateUniversityFundRequest(requestId, StatusId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating university request: {ex.Message}");
            }
        }

        public UniversityRequest NewUniversityRequest(int universityID, decimal amount, string comment)
        {
            try
            {
                return _repository.NewUniversityFundRequest(universityID, amount, comment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new university request: {ex.Message}");
            }
        }

        public IEnumerable<AllocationDetails> GetAllocationDetails()
        {
            try
            {
                return _repository.GetUniversityFundAllocations();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting allocation details: {ex.Message}");
            }
        }

        public void Allocate()
        {
            try
            {
                _repository.Allocate();
            }
            catch (Exception ex)
            {
                throw new Exception("Error allocating funds", ex);
            }
        }

        ///
        public void AddUniversity(Models.AddUniversityAndUser newRequest)
        {
            if (newRequest != null)
                try
                {
                    DataAccess.Entity.AddUniversityAndUser dataAccessModel = new()
                    {
                        UniversityName = newRequest.UniversityName,
                        ProvinceID = newRequest.ProvinceID,
                        FirstName = newRequest.FirstName,
                        LastName = newRequest.LastName,
                        Email = newRequest.Email,
                        PhoneNumber = newRequest.PhoneNumber,
                        DepartmentID = newRequest.DepartmentID

                    };

                    _repository.AddUniversity(dataAccessModel);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error creating student fund request" + ex.StackTrace);
                }
            else
                throw new ArgumentNullException(nameof(newRequest));
        }
    }
}