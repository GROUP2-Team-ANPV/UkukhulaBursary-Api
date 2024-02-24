using DataAccess.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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




        //public void CreateForExistingStudent(ExistingStudent newRequest)
        //{
        //    try
        //    {
        //        _connection.Open();
        //        string query = "INSERT INTO [dbo].[StudentFundRequest] ([Grade], [Amount], [Comment], [StudentID], [StatusID])VALUES (@Grade, @Amount, '', @StudentID, 3)";
        //        using (SqlCommand command = new SqlCommand(query, _connection))
        //        {
        //            command.Parameters.AddWithValue("@StudentID", newRequest.StudentID);
        //            command.Parameters.AddWithValue("@Grade", newRequest.Grade);
        //            command.Parameters.AddWithValue("@Amount", newRequest.Amount);

        //            command.ExecuteNonQuery();
        //            _connection.Close();
        //        }
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }
        //}

        //public void UpdateRequest(int id, UpdateStudentFundRequest updatedRequest)
        //{
        //    try
        //    {
        //        _connection.Open();
        //        string query = "UPDATE StudentFundRequest SET Grade = @Grade, Amount = @Amount WHERE ID = @ID AND StatusID = 3";
        //        using (SqlCommand command = new SqlCommand(query, _connection))
        //        {
        //            command.Parameters.AddWithValue("@Grade", updatedRequest.Grade);
        //            command.Parameters.AddWithValue("@Amount", updatedRequest.Amount);
        //            command.Parameters.AddWithValue("@ID", id);

        //            int rowsAffected = command.ExecuteNonQuery();
        //            if (rowsAffected == 0)
        //            {   
        //                _connection.Close() ;
        //                throw new KeyNotFoundException("Student fund request not found!");
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }
        //}



    }
}