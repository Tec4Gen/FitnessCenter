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
                command.CommandText = "[dbo].[InsertHall]";

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
            throw new NotImplementedException();
        }

        public Hall GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
