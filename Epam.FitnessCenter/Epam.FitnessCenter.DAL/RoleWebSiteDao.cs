using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class RoleWebSiteDao : IRoleWebSiteDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FitnessCenter"].ConnectionString;
        public IEnumerable<RoleWebSite> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRole";

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var listRole = new List<RoleWebSite>();

                    while (reader.Read())
                    {
                        listRole.Add(new RoleWebSite 
                        {
                            Id = (int)reader["Id"],
                            Name = reader["RolewebSite"] as string
                        });
                    }
                    return listRole;
                }
                catch
                {

                    throw;
                }
            }
        }
    }
}
