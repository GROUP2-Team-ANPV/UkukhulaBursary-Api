using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class BBDAdminDAL
    {
        private readonly SqlConnection _connection;

        public BBDAdminDAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<GetAllUniversities> GetAllRequests()
        {
            try
            {
                _connection.Open();
                List<GetAllUniversities> requests = new List<GetAllUniversities>();
                string query = "EXEC [dbo].[GetAllUniversities]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetAllUniversities request = new GetAllUniversities
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            UniversityName = reader.GetString(reader.GetOrdinal("Name")),
                            ProvinceName = reader.GetString(reader.GetOrdinal("ProvinceName")),
                            ContactPerson = reader.GetString(reader.GetOrdinal("ContactPerson")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
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


        

        public void AddUniversity(AddUniversityAndUser newRequest)
        {
            try
            {
                _connection.Open();

                string query = "EXEC [dbo].[AddUniversityAndUser] @UniversityName, @ProvinceID, @FirstName, @LastName, @Email, @PhoneNumber, @RoleID, @DepartmentID";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UniversityName", newRequest.UniversityName);
                    command.Parameters.AddWithValue("@ProvinceID", newRequest.ProvinceID);
                    command.Parameters.AddWithValue("@FirstName", newRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", newRequest.LastName);
                    command.Parameters.AddWithValue("@Email", newRequest.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", newRequest.PhoneNumber);
                    command.Parameters.AddWithValue("@RoleID", 2); 
                    command.Parameters.AddWithValue("@DepartmentID", newRequest.DepartmentID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing AddUniversityAndUser: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void UpdateApplicationStatus(int applicationId, int status, string comment)
        {
            try
            {
                _connection.Open();

                if (status == 2 && string.IsNullOrWhiteSpace(comment))
                {
                    throw new ArgumentException("A comment is required when changing the status to 2.");
                }

                string query;

                if (!string.IsNullOrWhiteSpace(comment))
                {
                    query = "UPDATE StudentFundRequest SET StatusID = @Status, Comment = @Comment WHERE ID = @ID";
                }
                else
                {
                    query = "UPDATE StudentFundRequest SET StatusID = @Status WHERE ID = @ID";
                }

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@ID", applicationId);

                    if (!string.IsNullOrWhiteSpace(comment))
                    {
                        command.Parameters.AddWithValue("@Comment", comment);
                    }

                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AddUniversityUser(AddUniversityUser newRequest)
        {
            try
            {
                _connection.Open();

                string query = "EXEC [dbo].[AddUniversityUser] @UniversityID, @FirstName, @LastName, @Email, @PhoneNumber, @DepartmentID";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UniversityID", newRequest.UniversityID);
                    command.Parameters.AddWithValue("@FirstName", newRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", newRequest.LastName);
                    command.Parameters.AddWithValue("@Email", newRequest.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", newRequest.PhoneNumber);
                    command.Parameters.AddWithValue("@DepartmentID", newRequest.DepartmentID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing AddUniversityUser: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<GetUsers> GetUniversityUsers()
        {
            try
            {
                _connection.Open();
                List<GetUsers> requests = new List<GetUsers>();
                string query = "EXEC [dbo].[GetUniversityUser]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetUsers request = new ()
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            UniversityName = reader.GetString(reader.GetOrdinal("UniversityName")),
                            DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
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

        public IEnumerable<GetUsers> GetUserByUniversityID(int UniversityID)
        {
            try
            {
                _connection.Open();
                List<GetUsers> requests = new List<GetUsers>();
                string query = "EXEC [dbo].[GetUserByUniversityID] @UniversityID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UniversityID", UniversityID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetUsers request = new()
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                UniversityName = reader.GetString(reader.GetOrdinal("UniversityName")),
                                DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                            };
                            requests.Add(request);
                        }
                    }
                    _connection.Close();
                    return requests;
                }             

            }
            finally
            {
                _connection.Close();
            }
        }
        public IEnumerable<BBDFund> BBDFund()
        {
            try
            {
                _connection.Open();
                List<BBDFund> requests = new List<BBDFund>();
                string query = "SELECT * FROM [dbo].[BBDAllocation]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BBDFund request = new()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year")),
                            Budget = reader.GetDecimal(reader.GetOrdinal("Budget")),
                            RemainingBudget = reader.GetDecimal(reader.GetOrdinal("RemainingBudget")),
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
    }
}