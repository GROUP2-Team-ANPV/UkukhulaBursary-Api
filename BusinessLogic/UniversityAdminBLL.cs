using DataAccess.Entity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Net;
using BusinessLogic.Models.Response;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessLogic
{
    public class UniversityAdminBLL
    {
        private readonly UniversityAdminDAL _repository;
        public UniversityAdminBLL(UniversityAdminDAL repository)
        {
            _repository = repository;
        }

        public IEnumerable<GetAllStudents> GetAllStudents()
        {
            try
            {
                return _repository.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }
        }

        public IEnumerable<GetAllStudents> GetStudentsByUniversityID(int universityID)
        {
            try
            {
                return _repository.GetStudentsByUniversityID(universityID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }
        }

        public GetAllStudents GetStudentByID(int studentID)
        {
            try
            {
                return _repository.GetStudentByID(studentID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }
        }


        public void Create(Models.StudentFundRequest newRequest)
        {
            if (newRequest != null)
            {
                try
                {
                    StudentFundRequest dataAccessModel = new()
                    {
                        FirstName = newRequest.FirstName,
                        LastName = newRequest.LastName,
                        IDNumber = newRequest.IDNumber,
                        BirthDate = newRequest.BirthDate,
                        GenderID = newRequest.GenderID,
                        RaceID = newRequest.RaceID,
                        Email = newRequest.Email,
                        PhoneNumber = newRequest.PhoneNumber,
                        Grade = newRequest.Grade,
                        Amount = newRequest.Amount,
                        Motivation = newRequest.Motivation,
                        DepartmentID = newRequest.DepartmentID,
                        UniversityID = newRequest.UniversityID
                    };

                    _repository.Create(dataAccessModel);
                }
                catch (Exception)
                {
                    throw new Exception("Error creating student fund request");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(newRequest));
            }
        }
        public IEnumerable<FundRequest> GetAllFundRequests()
        {
            try
            {
                return _repository.GetAllFundRequests();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students fund requests: {ex.Message}");
            }
        }

        public FundRequest GetFundRequestByID(int FundID)
        {
            try
            {
                return _repository.GetFundRequestByID(FundID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students fund requests: {ex.Message}");
            }
        }


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


        public void UpdateFundRequest(int FundRequestID, Models.UpdateFundRequest newRequest)
        {
            if (newRequest == null)
                throw new ArgumentNullException(nameof(newRequest));

            try
            {
                UpdateFundRequest updatedRequest = new()
                {
                    Grade = newRequest.Grade,
                    Amount = newRequest.Amount,
                    Motivation =  newRequest.Motivation,
                    StudentID = newRequest.StudentID,
                    DepartmentID = newRequest.DepartmentID,
                };
                _repository.UpdateFundRequest(FundRequestID, updatedRequest);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student fund request: {ex.Message}");
            }
        }

        public GetDocument GetDocumentByFundRequestID(int FundID)
        {
            try
            {
                return _repository.GetDocumentByFundRequestID(FundID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving document: {ex.Message}");
            }
        }

    }
}
