using DataAccess.Entity;
using DataAccess;
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

        public GetAllUniversities GetAllUniversityByID(int UniversityID)
        {
            try
            {
                return _repository.GetAllUniversityByID(UniversityID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student fund requests: {ex.Message}");
            }
        }

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

        public void AddUniversityUser(Models.AddUniversityUser newRequest)
        {
            if (newRequest != null)
                try
                {
                    DataAccess.Entity.AddUniversityUser dataAccessModel = new()
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

        //public void Create(Models.CreateStudentFundRequestForNewStudent newRequest)
        //{
        //    if (newRequest != null)
        //        try
        //        {
        //            Models.Register userRequest = new()
        //            {

        //                FirstName = newRequest.FirstName,
        //                LastName = newRequest.LastName,
        //                Email = newRequest.Email,
        //                PhoneNumber = newRequest.PhoneNumber,
        //                Role = "Student",
        //                Password = "P@ssword1",
        //                ConfirmPassword = "P@ssword1"

        //            };
        //            IdentityUser StudentUser = new IdentityUser
        //            {
        //                Email = newRequest.Email,
        //                UserName = newRequest.Email,
        //                PhoneNumber = newRequest.PhoneNumber,
        //            };

        //            var result = _userDAL.RegisterIdentityUser(StudentUser, userRequest.Password, userRequest.Role).Result;
        //            if (result.Succeeded)//Check if user Identity has been added successfully
        //            {
        //                //Create Contacts object and insert to table,
        //                ContactDetails contactDetails = new ContactDetails
        //                {
        //                    Email = newRequest.Email,
        //                    PhoneNumber = newRequest.PhoneNumber,
        //                };
        //                int contactId = _userDAL.InsertContactsAndGetPrimaryKey(contactDetails);

        //                //create User object and insert User
        //                User user = new User
        //                {
        //                    FirstName = newRequest.FirstName,
        //                    LastName = newRequest.LastName,
        //                    ContactID = contactId,
        //                };
        //                int userId = _userDAL.InsertUserAndGetPrimaryKey(user);

        //                //insert UserRole Reference
        //                _userDAL.InsertToUserRole(userId, userRequest.Role);




        //                // Convert the business logic model to the data access model
        //                CreateStudentFundRequestForNewStudent dataAccessModel = new()
        //                {
        //                    IDNumber = newRequest.IDNumber,
        //                    FirstName = newRequest.FirstName,
        //                    LastName = newRequest.LastName,
        //                    Email = newRequest.Email,
        //                    PhoneNumber = newRequest.PhoneNumber,
        //                    GenderName = newRequest.GenderName,
        //                    RaceName = newRequest.RaceName,
        //                    UniversityID = newRequest.UniversityID,
        //                    BirthDate = newRequest.BirthDate,
        //                    Grade = newRequest.Grade,
        //                    Amount = newRequest.Amount,
        //                    UserID = userId

        //                };

        //                _repository.Create(dataAccessModel);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error creating student fund request" + ex.StackTrace);
        //        }
        //    else
        //        throw new ArgumentNullException(nameof(newRequest));
        //}

        //public void CreateForExistingStudent(Models.ExistingStudent newRequest)
        //{
        //    if (newRequest != null)
        //        try
        //        {
        //            ExistingStudent dataAccessModel = new()
        //            {
        //                StudentID = newRequest.StudentID,
        //                Grade = newRequest.Grade,
        //                Amount = newRequest.Amount
        //            };

        //            _repository.CreateForExistingStudent(dataAccessModel);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error creating student fund request" + ex.StackTrace);
        //        }
        //    else
        //        throw new ArgumentNullException(nameof(newRequest));
        //}


        //public void UpdateRequest(int id, Models.UpdateStudentFundRequest newRequest)
        //{
        //    if (newRequest == null)
        //        throw new ArgumentNullException(nameof(newRequest));

        //    try
        //    {
        //        UpdateStudentFundRequest updatedRequest = new()
        //        {
        //            Grade = newRequest.Grade,
        //            Amount = newRequest.Amount
        //        };
        //        _repository.UpdateRequest(id, updatedRequest);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error updating student fund request: {ex.Message}");
        //    }
        //}

        //public void ApproveApplication(int applicationId)
        //{
        //    try
        //    {
        //        _repository.UpdateApplicationStatus(applicationId, 1, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error approving application: {ex.Message}");
        //    }
        //}

        //public void RejectApplication(int applicationId, string comment)
        //{
        //    try
        //    {
        //        _repository.UpdateApplicationStatus(applicationId, 2, comment);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error rejecting application: {ex.Message}");
        //    }
        //}


    }
}
