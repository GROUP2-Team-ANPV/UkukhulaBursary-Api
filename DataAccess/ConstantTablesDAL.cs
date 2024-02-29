using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess
{
    public class ConstantTablesDAL
    {
        private readonly SqlConnection _connection;

        public ConstantTablesDAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ConstantTables> Department()
        {
            try
            {
                _connection.Open();
                List<ConstantTables> requests = new List<ConstantTables>();
                string query = "SELECT * FROM [dbo].[Department]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConstantTables request = new()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),

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

        public IEnumerable<ConstantTables> Gender()
        {
            try
            {
                _connection.Open();
                List<ConstantTables> requests = new List<ConstantTables>();
                string query = "SELECT * FROM [dbo].[Gender]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConstantTables request = new()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("GenderName")),

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


        public IEnumerable<ConstantTables> Provinces()
        {
            try
            {
                _connection.Open();
                List<ConstantTables> requests = new List<ConstantTables>();
                string query = "SELECT * FROM [dbo].[Provinces]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConstantTables request = new()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("ProvinceName")),

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

        public IEnumerable<ConstantTables> Race()
        {
            try
            {
                _connection.Open();
                List<ConstantTables> requests = new List<ConstantTables>();
                string query = "SELECT * FROM [dbo].[Race]";
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConstantTables request = new()
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("RaceName")),

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