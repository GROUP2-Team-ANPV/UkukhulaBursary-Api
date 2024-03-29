﻿using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

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
        public UniversityDTO GetUniversityAndTheirStudents(int universityID)
        {
            try
            {
                return _repository.GetUniversityAndTheirStudents(universityID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving university: {ex.Message}");
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


        public void Create(StudentFundRequest newRequest)
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



        public void UpdateFundRequest(int FundRequestID, UpdateFundRequest newRequest)
        {
            if (newRequest == null)
                throw new ArgumentNullException(nameof(newRequest));

            try
            {
                UpdateFundRequest updatedRequest = new()
                {
                    FirstName = newRequest.FirstName,
                    LastName = newRequest.LastName,
                    Age = newRequest.Age,
                    IDNumber =newRequest.IDNumber,
                    BirthDate= newRequest.BirthDate,
                    Gender = newRequest.Gender,
                    Race = newRequest.Race,
                    Email = newRequest.Email,
                    PhoneNumber = newRequest.PhoneNumber,
                    Grade = newRequest.Grade,
                    Amount = newRequest.Amount,
                    Motivation =  newRequest.Motivation,
                    StudentID = newRequest.StudentID,
                    
                    
                };
                _repository.UpdateFundRequest(FundRequestID, updatedRequest);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student fund request: {ex.Message}");
            }
        }

        public IEnumerable<GetDocument> GetDocumentByFundRequestID(int FundID)
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

        public List<UniversityAmount> GetUniversityAmounts()
        {
            try{
                
                return (List<UniversityAmount>)_repository.GetUniversityAmount();
            }catch(Exception e){
               throw new Exception($"Error retrieving university amount: {e.Message}");
            }
        }

        public bool DeleteFundRequest(int fundRequestID)
        {
                try
                {
                    
                    return _repository.DeleteFundRequest(fundRequestID);
                }
                catch (Exception ex)
                {
                    
                    throw new Exception($"Error deleting student fund request: {ex.Message}");
                }
        }
    }
}
