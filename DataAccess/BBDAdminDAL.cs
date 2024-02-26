using DataAccess.Entity;
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


        public GetAllUniversities GetAllUniversityByID(int UniversityID)
        {
            try
            {
                _connection.Open();
                List<GetAllUniversities> requests = new List<GetAllUniversities>();
                string query = "EXEC [dbo].[GetUniversityByID] @UniversityID";
                using (SqlCommand command = new SqlCommand(query, _connection)) 
                {
                    command.Parameters.AddWithValue("@UniversityID", UniversityID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GetAllUniversities request = new GetAllUniversities
                            {
                                UniversityName = reader.GetString(reader.GetOrdinal("Name")),
                                ProvinceName = reader.GetString(reader.GetOrdinal("ProvinceName")),
                                ContactPerson = reader.GetString(reader.GetOrdinal("ContactPerson")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            };
                            return request;
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

        //Ukukhula Front-end
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
                    command.Parameters.AddWithValue("@RoleID", 2); //2 is the ID for the University Admin role
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
    }
}