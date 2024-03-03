using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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
                            HODS = reader.GetInt32(reader.GetOrdinal("HODS")),
                            Students = reader.GetInt32(reader.GetOrdinal("HODS")),
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
                    string query = "SELECT ID, Budget, AmountUsed, FundedUniversities, Year FROM [dbo].[uspGetBBDFundsDetails]";
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
                                AmountUsed = reader.GetDecimal(reader.GetOrdinal("AmountUsed")),
                                FundedUniversities = reader.GetInt32(reader.GetOrdinal("FundedUniversities"))
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


            public void UpdateApplicationStatus(int applicationId, string status ,string comment)
            {
                try
                {
                    _connection.Open();

                    string query = "UPDATE StudentFundRequest SET StatusID = @Status, Comment = @Comment WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.Parameters.AddWithValue("@ID", applicationId);

                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    _connection.Close();
                }
            }

            

            public void AllocateFunds()
            {
                try
                {
                    _connection.Open();

                    
                    string countQuery = "SELECT COUNT(*) FROM dbo.University";
                    int totalUniversities;
                    using (SqlCommand countCommand = new SqlCommand(countQuery, _connection))
                    {
                        totalUniversities = (int)countCommand.ExecuteScalar();
                    }

                    
                    string budgetQuery = "SELECT Budget FROM dbo.BBDAllocation WHERE Year= 2024";
                    decimal budget;
                    using (SqlCommand budgetCommand = new SqlCommand(budgetQuery, _connection))
                    {
                        budget = (decimal)budgetCommand.ExecuteScalar();
                    }

                    
                    decimal equalAmount = budget / totalUniversities;


                    string insertOrUpdateQuery = @"
                    UPDATE UFA
                    SET Budget = @EqualAmount
                    FROM dbo.UniversityFundAllocation UFA
                    INNER JOIN dbo.University U ON UFA.UniversityID = U.ID
                    WHERE UFA.UniversityID = @UniversityID;";
                    
                    using (SqlCommand command = new SqlCommand(insertOrUpdateQuery, _connection))
                    {
                        command.Parameters.AddWithValue("@EqualAmount", equalAmount);


                                SqlParameter universityIdParameter = command.Parameters.AddWithValue("@UniversityID", SqlDbType.Int);
                                
                                for (int universityID = 1; universityID <= totalUniversities; universityID++)
                                {
                                    
                                    universityIdParameter.Value = universityID;
                                    command.ExecuteNonQuery();
                                }

    
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error allocating funds: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }

            

        
        public void AllocateUniversityFunds(AllocateFunds dataAccessModel)
        {
            try
            {
                _connection.Open();

                decimal bbdAllocationBudget = 200000000;

                
                if (bbdAllocationBudget < dataAccessModel.AllocatedAmount)
                {
                    throw new Exception("BBDAllocation budget is insufficient for the allocated amount.");
                }else{

                        string query = @"
                                        IF EXISTS (SELECT 1 FROM UniversityFundAllocation WHERE UniversityID = @UniversityId)
                                        BEGIN
                                            UPDATE UniversityFundAllocation
                                            SET Budget = @AllocatedAmount
                                            WHERE UniversityID = @UniversityId;
                                        END
                                        ELSE
                                        BEGIN
                                            INSERT INTO UniversityFundAllocation (UniversityID, Budget)
                                            VALUES (@UniversityId, @AllocatedAmount);
                                        END;
                                    ";

                        using (SqlCommand command = new SqlCommand(query, _connection))
                        {
                            command.Parameters.AddWithValue("@UniversityId", dataAccessModel.UniversityID);
                            command.Parameters.AddWithValue("@AllocatedAmount", dataAccessModel.AllocatedAmount);
                            command.ExecuteNonQuery();
                        }

                    

                    }
            }
                    finally
                    {
                        _connection.Close();
                    }
            
            }

        public decimal GetRemainingAmount(int bBDAllocationID)
        {
            throw new NotImplementedException();
        }


        public decimal GetBBDRemainingAmount(int bbdAllocationID)
        {
            try
            {
                _connection.Open();
                string query = "SELECT Budget - AmountUsed AS RemainingAmount FROM dbo.BBDAllocation WHERE Year = 2024;";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@BBDAllocationID", bbdAllocationID);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
            finally
            {
                _connection.Close();
            }
        }

    }

}
