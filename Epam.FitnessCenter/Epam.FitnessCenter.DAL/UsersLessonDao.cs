using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class UsersLessonDao : IUsersLessonDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FintessCenter"].ConnectionString;

        public void Add(UsersLesson usersLesson)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertUsersLesson";

                SqlParameter parameterIdUser = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = usersLesson.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdUser);

                SqlParameter parameterIdLesson = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdLesson",
                    Value = usersLesson.IdLesson,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdLesson);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch
                {

                    throw;
                }
            }
        }

        public IEnumerable<UsersLesson> GetAllLessonsByIdUser(int idUser)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllLessonsByIdUser";

                SqlParameter parameterIdUser = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdUser);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var listUsersLesson = new List<UsersLesson>();

                    while (reader.Read())
                    {
                        listUsersLesson.Add(new UsersLesson
                        {
                            Id = (int)reader["Id"],
                            IdUser = (int)reader["IdUser"],
                            IdLesson = (int)reader["IdLesson"]
                        });
                    }

                    return listUsersLesson;
                }
                catch
                {

                    throw;
                }
            }
        }

        public IEnumerable<UsersLesson> GetAllUsersByIdLesson(int idLesson)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersByIdLesson";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdLesson",
                    Value = idLesson,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var listUsersLesson = new List<UsersLesson>();

                    while (reader.Read())
                    {
                        listUsersLesson.Add(new UsersLesson
                        {
                            Id = (int)reader["Id"],
                            IdUser = (int)reader["IdUser"],
                            IdLesson = (int)reader["IdLesson"]
                        });
                    }
                    return listUsersLesson;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public UsersLesson GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUsersLessonById";

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
                        return new UsersLesson 
                        {
                            Id = (int)reader["Id"],
                            IdUser = (int)reader["IdUser"],
                            IdLesson = (int)reader["IdLesson"]
                        };
                    }
                    return null;
                }
                catch 
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
                command.CommandText = "dbo.DeleteUsersLesson";

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

                }
            }
        }
    }
}
