﻿using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using Epam.FitnessCenter.Logger;
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
                    Logs.Log.Info($"All Role Received");

                    return listRole;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public RoleWebSite GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleById";

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
                        return new RoleWebSite
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string,
                        };
                    }
                    Logs.Log.Info("Role received");
                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }
    }
}