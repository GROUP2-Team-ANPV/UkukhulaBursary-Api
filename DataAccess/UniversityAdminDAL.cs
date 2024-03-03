using DataAccess.DTO;
using DataAccess.Models;
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
                           

                        }
                        if (reader.NextResult())
                        {
                            universityDTO.FundAllocation = new List<UniversityFundAllocationDTO>();
                            while (reader.Read())
                            {
                                UniversityFundAllocationDTO fundAllocationDTO = new UniversityFundAllocationDTO
                                {
                                    TotalAmount = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    Balance = reader.GetDecimal(reader.GetOrdinal("Balance")),
                                    Year = reader.GetInt32(reader.GetOrdinal("Year"))
                                };
                                universityDTO.FundAllocation.Add(fundAllocationDTO);
                            }
                        }

                        if (reader.NextResult())
                        {
                            universityDTO.HeadOfDepartment = new List<HeadOfDepartmentDTO>();
                            while (reader.Read())
                            {
                                HeadOfDepartmentDTO headOfDepartment = new HeadOfDepartmentDTO
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName"))
                                };
                                universityDTO.HeadOfDepartment.Add(headOfDepartment);
                            }
                        }

                        // Move to the next result set (List of Students)
                        if (reader.NextResult())
                        {
                            universityDTO.Students = new List<StudentDTO>();

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
                                    ApplicationStatus = reader.GetString(reader.GetOrdinal("ApplicationStatus")),
                                    Grade = reader.GetByte(reader.GetOrdinal("Grade")), 
                                    Motivation = reader.GetString(reader.GetOrdinal("Motivation")), 
                                    Comment = reader.GetString(reader.GetOrdinal("Comment")),  
                                    ApplicationDate = reader.GetDateTime(reader.GetOrdinal("ApplicationDate"))
                                    
                                  
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

                string query = @"
                    UPDATE dbo.StudentFundRequest
                    SET 
                        Grade = @Grade,
                        Amount = @Amount,
                        Motivation = @Motivation
                    WHERE
                        ID = @FundRequestID;

                    UPDATE dbo.Student
                    SET 
                        IDNumber = @IDNumber,
                        BirthDate = @BirthDate,
                        RaceID = @Race,
                        GenderID = @Gender
                    WHERE
                        ID = (SELECT StudentID FROM dbo.StudentFundRequest WHERE ID = @FundRequestID);

                    UPDATE dbo.[User]
                    SET 
                        FirstName = @FirstName,
                        LastName = @LastName
                    WHERE
                        ID = (SELECT UserID FROM dbo.Student WHERE ID = (SELECT StudentID FROM dbo.StudentFundRequest WHERE ID = @FundRequestID));

                    UPDATE dbo.ContactDetails
                    SET 
                        Email = @Email,
                        PhoneNumber = @PhoneNumber
                    WHERE
                        ID = (SELECT ContactID FROM dbo.[User] WHERE ID = (SELECT UserID FROM dbo.Student WHERE ID = (SELECT StudentID FROM dbo.StudentFundRequest WHERE ID = @FundRequestID)));
                ";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@FirstName", updatedRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", updatedRequest.LastName);
                    command.Parameters.AddWithValue("@Age", updatedRequest.Age);
                    command.Parameters.AddWithValue("@IDNumber", updatedRequest.IDNumber);
                    command.Parameters.AddWithValue("@BirthDate", updatedRequest.BirthDate);
                    command.Parameters.AddWithValue("@Gender", updatedRequest.Gender);
                    command.Parameters.AddWithValue("@Race", updatedRequest.Race);
                    command.Parameters.AddWithValue("@Email", updatedRequest.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", updatedRequest.PhoneNumber);
                    command.Parameters.AddWithValue("@FundRequestID", FundRequestID);
                    command.Parameters.AddWithValue("@Grade", updatedRequest.Grade);
                    command.Parameters.AddWithValue("@Amount", updatedRequest.Amount);
                    command.Parameters.AddWithValue("@Motivation", updatedRequest.Motivation);

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



            public IEnumerable<UniversityAmount> GetUniversityAmount()
            {
                List<UniversityAmount> result = new List<UniversityAmount>();

                try
                {
                    _connection.Open();
                    string query = @"
                       SELECT U.Name AS UniversityName,
                            ISNULL(SUM(UFA.Budget), 0) AS TotalAllocatedAmount
                        FROM dbo.University U
                        INNER JOIN dbo.UniversityFundAllocation UFA ON U.ID = UFA.UniversityID
                        INNER JOIN dbo.BBDAllocation B ON UFA.BBDAllocationID = B.ID
                        WHERE B.[Year] = 2023
                        GROUP BY U.Name;
                    ";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UniversityAmount universityAmount = new UniversityAmount();
                            universityAmount.UniversityName = reader.GetString(reader.GetOrdinal("UniversityName"));
                            universityAmount.Amount = reader.GetDecimal(reader.GetOrdinal("TotalAllocatedAmount"));

                            result.Add(universityAmount);
                        }
                        return result;
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

        public class UniversityAmount
        {

        public decimal Amount { get; set; }
        public string UniversityName { get; set; }
        }
    
