using Epam.FitnessCenter.DAL.Interface;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class MyRoleProviderDao : IMyRoleProviderDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FitnessCenter"].ConnectionString;

        public string[] GetRolesForUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetRolesForUser]";

                SqlParameter parameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@UserName",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterUserName);

                connection.Open();
                var reader = command.ExecuteReader();

                List<string> roles = new List<string>();
                while (reader.Read())
                {
                    roles.Add(reader["Name"] as string);
                }
                return roles.ToArray();
            }
        }

        public string[] GetUsersInRole(string roleName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetUsersInRole]";

                SqlParameter parameterRoleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@RoleName",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterRoleName);

                connection.Open();
                var reader = command.ExecuteReader();

                List<string> usernames = new List<string>();
                while (reader.Read())
                {
                    usernames.Add(reader["UserName"] as string);
                }
                return usernames.ToArray();
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_GetRole]";

                SqlParameter ParameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterUserName);

                SqlParameter ParameterRoleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Role",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterRoleName);

                connection.Open();

                var resultRole = commnad.ExecuteScalar() as string;

                return resultRole == roleName ? true : false;
            }
        }

    }
}
