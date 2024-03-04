using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic
{
    public class BBDAdminBLL
    {
        private readonly BBDAdminDAL _repository;
        public BBDAdminBLL(BBDAdminDAL repository)
        {
            _repository = repository;
        }

        public IEnumerable<GetAllUniversities> GetAllRequests()
        {
            try
            {
                return _repository.GetAllRequests();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student fund requests: {ex.Message}");
            }
        }

      

        public void AddUniversity(AddUniversityAndUser newRequest)
        {
            if (newRequest != null)
                try
                {
                    AddUniversityAndUser dataAccessModel = new()
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

        public void ApproveApplication(int applicationId)
        {
            try
            {
                _repository.UpdateApplicationStatus(applicationId, 1, "");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error approving application: {ex.Message}");
            }
        }

        public void RejectApplication(int applicationId, string comment)
        {
            try
            {
                _repository.UpdateApplicationStatus(applicationId, 2, comment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error rejecting application: {ex.Message}");
            }
        }

        public void AddUniversityUser(AddUniversityUser newRequest)
        {
            if (newRequest != null)
                try
                {
                    AddUniversityUser dataAccessModel = new()
                    {
                        UniversityID = newRequest.UniversityID,
                        FirstName = newRequest.FirstName,
                        LastName = newRequest.LastName,
                        Email = newRequest.Email,
                        PhoneNumber = newRequest.PhoneNumber,
                        DepartmentID = newRequest.DepartmentID

                    };

                    _repository.AddUniversityUser(dataAccessModel);
                }
                catch (Exception)
                {
                    throw new Exception("Error creating university user");
                }
            else
                throw new ArgumentNullException(nameof(newRequest));
        }

        public IEnumerable<GetUsers> GetUniversityUsers()
        {
            try
            {
                return _repository.GetUniversityUsers();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user: {ex.Message}");
            }
        }

        public IEnumerable<GetUsers> GetUserByUniversityID(int UniversityID)
        {
            try
            {
                return _repository.GetUserByUniversityID(UniversityID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student fund requests: {ex.Message}");
            }
        }

        public IEnumerable<BBDFund> BBDFund()
        {
            try
            {
                return _repository.BBDFund();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting university requests: {ex.Message}");
            }
        }

        public void UpdateStatus(int applicationId, string status, string comment)
        {
            try
            {

                _repository.UpdateApplicationStatus(applicationId, status,comment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating application status: {ex.Message}");
            }
        }

        public void AllocateFunds()
        {
            try
            {

                // decimal remainingAmount = _repository.GetBBDRemainingAmount(allocation.BBDAllocationID);
                
                
                // if (allocation.Budget > remainingAmount)
                // {
                    // throw new Exception("Allocated amount exceeds the remaining amount in BBDAllocation.");
                    
                // }else{
                     _repository.AllocateFunds();
                // }

               
            }
            catch (Exception ex)
            {
                throw new Exception($"Error allocating funds: {ex.Message}");
            }
        }






        public void AllocateUniversityFunds(AllocateFunds newRequest)
        {


            if (newRequest != null)
                try
                {
                    AllocateFunds dataAccessModel = new()
                    {
                        UniversityID = newRequest.UniversityID,
                        AllocatedAmount = newRequest.AllocatedAmount,


                    };

                    _repository.AllocateUniversityFunds(dataAccessModel);
                }
                catch (Exception)
                {
                    throw new Exception("Error loading funds");
                }
            else
                throw new ArgumentNullException(nameof(newRequest));
            
        }
    }
}
