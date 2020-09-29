using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FintessCenter"].ConnectionString;

        public void Add(User user)
        {
            using (SqlConnection connection =  new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertUser";

                SqlParameter parameterFirstName = new SqlParameter 
                {
                    DbType = DbType.String,
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterFirstName);

                SqlParameter parameterLastName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@LastName",
                    Value = user.LastName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLastName);

                SqlParameter parameterMiddleName = new SqlParameter 
                {
                    DbType = DbType.String,
                    ParameterName = "@MiddleName",
                    Value = user.MiddleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterMiddleName);

                SqlParameter parameterLogin = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLogin);

                SqlParameter parameterHashPassword = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName  = "@HashPassword",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterHashPassword);

                SqlParameter parameterRoleWebSite = new SqlParameter 
                {
                    DbType = DbType.Binary,
                    ParameterName = "@RoleWebSite",
                    Value = user.RoleWebSite,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterRoleWebSite);

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

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "@GetAllUsers";

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var listUsers = new List<User>();

                    while (reader.Read())
                    {
                        listUsers.Add(new User 
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"] as string,
                            LastName = reader["LastName"] as string,
                            MiddleName = reader["MiddleName"] as string,
                            RoleWebSite = (int)reader["RoleWebSite"]
                         });
                    }
                    return listUsers;

                }
                catch (Exception)
                {

                    throw;
                }
             
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetuserById";

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
                        return new User 
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"] as string,
                            LastName = reader["LastName"] as string,
                            MiddleName = reader["MiddleName"] as string,
                            RoleWebSite = (int)reader["RoleWebSite"]
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUser";

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

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";

                SqlParameter parameterId = new SqlParameter 
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = user.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                SqlParameter parameterFirstName = new SqlParameter 
                {
                    DbType = DbType.String,
                    ParameterName = "@FistName",
                    Value = user.FirstName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterFirstName);

                SqlParameter parameterLastName = new SqlParameter 
                {
                    DbType = DbType.String,
                    ParameterName = "LastName",
                    Value = user.LastName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterLastName);


                SqlParameter parameterMiddleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "MiddleName",
                    Value = user.MiddleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterMiddleName);

                SqlParameter parameterRoleWebSite = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "RoleWebSite",
                    Value = user.MiddleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterRoleWebSite);

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
    }
}
