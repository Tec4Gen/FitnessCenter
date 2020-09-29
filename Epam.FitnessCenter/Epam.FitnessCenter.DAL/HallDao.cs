using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class HallDao : IHallDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FintessCenter"].ConnectionString;

        public void Add(Hall hall)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertHall";

                SqlParameter parameterNameHall = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = hall.NameHall,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterNameHall);
                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

        }

        public IEnumerable<Hall> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllHall";

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var hallList = new List<Hall>();

                    while (reader.Read())
                    {
                        hallList.Add(new Hall
                        {
                            Id = (int)reader["Id"],
                            NameHall = reader["NameHall"] as string
                        });
                    }

                    return hallList;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Hall GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetHallById";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Hall
                        {
                            Id = (int)reader["Id"],
                            NameHall = reader["NameHall"] as string
                        };
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Remove(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.DeleteHall";

                    SqlParameter parameterId = new SqlParameter
                    {
                        DbType = DbType.Int32,
                        ParameterName = "@Id",
                        Value = id,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(parameterId);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
