using DataAccess.DTO;
using DataAccess.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess
{
    public class UniversityAdminDAL
    {
        private readonly SqlConnection _connection;
        


        
        public UniversityAdminDAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public UniversityAdminDAL()
        {
        }

        public IEnumerable<GetAllStudents> GetAllStudents()
        {
            try
            {
                _connection.Open();
                List<GetAllStudents> requests = new List<GetAllStudents>();
                string query = "EXEC [dbo].[GetAllStudents]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetAllStudents request = new GetAllStudents
                        {
                            StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                            BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                            Age = reader.GetByte(reader.GetOrdinal("Age")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            Race = reader.GetString(reader.GetOrdinal("Race")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            University = reader.GetString(reader.GetOrdinal("University")),

                        };
                        requests.Add(request);
                    }
                }
                _connection.Close();
                return requests;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<GetAllStudents> GetStudentsByUniversityID(int universityID)
        {
            try
            {
               
                    _connection.Open();
                    
                
                List<GetAllStudents> students = new List<GetAllStudents>();
                string query = "EXEC [dbo].[GetStudentsByUniversityID] @UniversityID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UniversityID", universityID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetAllStudents student = new GetAllStudents
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                Age = reader.GetByte(reader.GetOrdinal("Age")),
                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                Race = reader.GetString(reader.GetOrdinal("Race")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                University = reader.GetString(reader.GetOrdinal("UniversityName"))
                            };
                            students.Add(student);
                        }
                    }
                }
                return students;
            }
            finally
            {
                
                    _connection.Close();
                    
                
                
            }
        }
        public UniversityDTO GetUniversityAndTheirStudents(int universityID)
        {
            try
            {
                UniversityDTO universityDTO = new UniversityDTO();

                _connection.Open();

                string query = "EXEC [GetUniversityInfoAndStudents] @UniversityID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UniversityID", universityID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Process the first result set (University Information)
                        if (reader.Read())
                        {
                            universityDTO.ID = reader.GetInt32(reader.GetOrdinal("UniversityID"));
                            universityDTO.Name = reader.GetString(reader.GetOrdinal("UniversityName"));
                            universityDTO.Province = reader.GetString(reader.GetOrdinal("ProvinceName"));
                            universityDTO.HODID = reader.GetInt32(reader.GetOrdinal("ContactID"));
                            universityDTO.HODFirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            universityDTO.HODLastName = reader.GetString(reader.GetOrdinal("LastName"));
                        }

                        // Move to the next result set (List of Students)
                        if (reader.NextResult())
                        {
                            universityDTO.Students = new List<StudentDTO>(); // Initialize the list

                            while (reader.Read())
                            {
                                StudentDTO student = new StudentDTO
                                {
                                    StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    Age = reader.GetByte(reader.GetOrdinal("Age")),
                                    IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                                    BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                    Race = reader.GetString(reader.GetOrdinal("Race")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    Amount = (Double) reader.GetDecimal(reader.GetOrdinal("Amount")), 
                                    ApplicationStatus = reader.GetString(reader.GetOrdinal("ApplicationStatus"))
                                };

                                universityDTO.Students.Add(student);
                            }
                        }
                    }
                }

                return universityDTO;
            }
            finally
            {
                _connection.Close();
            }
        }



        public GetAllStudents GetStudentByID(int studentID)
        {
            try
            {
                _connection.Open();
                string query = "EXEC [dbo].[GetStudentByID] @StudentID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if there's a student record
                        {
                            GetAllStudents student = new GetAllStudents
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                Age = reader.GetByte(reader.GetOrdinal("Age")),
                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                Race = reader.GetString(reader.GetOrdinal("Race")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                University = reader.GetString(reader.GetOrdinal("UniversityName"))
                            };
                            return student; // Return the student if found
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Create(StudentFundRequest newRequest)
        {
            try
            {
                _connection.Open();

                string query = "EXEC [dbo].[InsertStudentFundRequest] @FirstName,@LastName,@IDNumber,@BirthDate,@GenderID,@RaceID,@Email,@PhoneNumber,@Grade,@Amount,@Motivation,@DepartmentID,@UniversityID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FirstName", newRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", newRequest.LastName);
                    command.Parameters.AddWithValue("@IDNumber", newRequest.IDNumber);
                    command.Parameters.AddWithValue("@BirthDate", newRequest.BirthDate);
                    command.Parameters.AddWithValue("@GenderID", newRequest.GenderID);
                    command.Parameters.AddWithValue("@RaceID", newRequest.RaceID);
                    command.Parameters.AddWithValue("@Email", newRequest.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", newRequest.PhoneNumber);
                    command.Parameters.AddWithValue("@Grade", newRequest.Grade);
                    command.Parameters.AddWithValue("@Amount", newRequest.Amount);
                    command.Parameters.AddWithValue("@Motivation", newRequest.Motivation);
                    command.Parameters.AddWithValue("@DepartmentID", newRequest.DepartmentID);
                    command.Parameters.AddWithValue("@UniversityID", newRequest.UniversityID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create student fund request due to an unexpected error.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
        public FundRequest GetFundRequestByID(int FundID)
        {

            try
            {
                _connection.Open();
                string query = "EXEC [dbo].[GetFundRequestByID] @FundRequestID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FundRequestID", FundID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FundRequest fundRequest = new FundRequest
                            {
                                FundRequestID = reader.GetInt32(reader.GetOrdinal("FundRequestID")),
                                Grade = reader.GetByte(reader.GetOrdinal("Grade")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                Motivation = reader.GetString(reader.GetOrdinal("Motivation")),
                                ApplicationDate = reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                Comment = reader.GetString(reader.GetOrdinal("Comment")),
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                Race = reader.GetString(reader.GetOrdinal("Race")),
                                University = reader.GetString(reader.GetOrdinal("University")),
                                Department = reader.GetString(reader.GetOrdinal("Department")),
                                DocumentStatus = reader.GetString(reader.GetOrdinal("DocumentStatus"))
                            };

                            return fundRequest;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                    
            }
            finally
            {
                _connection.Close();
            }

        }

        public IEnumerable<FundRequest> GetAllFundRequests()
        {
            List<FundRequest> fundRequests = new List<FundRequest>();

            try
            {
                _connection.Open();

                string query = "EXEC [dbo].[GetAllFundRequests]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FundRequest fundRequest = new FundRequest
                        {
                            FundRequestID = reader.GetInt32(reader.GetOrdinal("FundRequestID")),
                            Grade = reader.GetByte(reader.GetOrdinal("Grade")),
                            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                            Motivation = reader.GetString(reader.GetOrdinal("Motivation")),
                            ApplicationDate = reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                            Status = reader.GetString(reader.GetOrdinal("Status")),
                            Comment = reader.GetString(reader.GetOrdinal("Comment")),
                            StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                            IDNumber = reader.GetString(reader.GetOrdinal("IDNumber")),
                            BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            Race = reader.GetString(reader.GetOrdinal("Race")),
                            University = reader.GetString(reader.GetOrdinal("University")),
                            Department = reader.GetString(reader.GetOrdinal("Department")),
                            DocumentStatus = reader.GetString(reader.GetOrdinal("DocumentStatus"))
                        };
                        fundRequests.Add(fundRequest);
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return fundRequests;
        }   

        public void UpdateFundRequest(int FundRequestID, UpdateFundRequest updatedRequest)
        {
            try
            {
                _connection.Open();
                string query = "UPDATE StudentFundRequest SET Grade = @Grade, Amount = @Amount, Motivation = @Motivation,StudentID = @StudentID, DepartmentID = @DepartmentID WHERE ID = @FundRequestID AND StatusID = 3";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FundRequestID", FundRequestID);
                    command.Parameters.AddWithValue("@Grade", updatedRequest.Grade);
                    command.Parameters.AddWithValue("@Amount", updatedRequest.Amount);
                    command.Parameters.AddWithValue("@Motivation", updatedRequest.Motivation);
                    command.Parameters.AddWithValue("@StudentID", updatedRequest.StudentID);
                    command.Parameters.AddWithValue("@DepartmentID", updatedRequest.StudentID);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        _connection.Close();
                        throw new KeyNotFoundException("Student fund request not found!");
                    }
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public GetDocument GetDocumentByFundRequestID(int FundID)
        {

            try
            {
                _connection.Open();
                string query = "EXEC [dbo].[GetDocumentsByRequestID] @FundRequestID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FundRequestID", FundID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GetDocument document = new GetDocument
                            {
                                DocumentPath = reader.GetString(reader.GetOrdinal("DocumentPath")),
                                DocumentType = reader.GetString(reader.GetOrdinal("DocumentType"))
                            };

                            return document;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
            finally
            {
                _connection.Close();
            }

        }

    }
}