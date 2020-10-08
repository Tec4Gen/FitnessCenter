using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using Epam.FitnessCenter.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.FitnessCenter.DAL
{
    public class LessonDao : ILessonDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FitnessCenter"].ConnectionString;

        public void Add(Lesson lesson)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "dbo.InsertLesson";

                SqlParameter parameterIdUserCoach = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUserCoach",
                    Value = lesson.IdUserCoach,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(parameterIdUserCoach);

                SqlParameter parameterIdHall = new SqlParameter
                {
                    DbType = DbType.Int32,
                    Value = lesson.IdHall,
                    ParameterName = "@IdHall",
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(parameterIdHall);

                SqlParameter parameterDateTime = new SqlParameter
                {
                    DbType = DbType.DateTime2,
                    ParameterName = "@DateTime",
                    Value = lesson.DateTime,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(parameterDateTime);

                SqlParameter parameterDescription = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Description",
                    Value = lesson.Description,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(parameterDescription);

                try
                {
                    connection.Open();

                    commnad.ExecuteNonQuery();

                    Logs.Log.Info("Lesson added");
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public IEnumerable<Lesson> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllLessons";

                SqlDataReader reader;
                try
                {
                   connection.Open();

                   reader = command.ExecuteReader();
                   
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }

                while (reader.Read())
                {
                   yield return new Lesson
                    {
                        Id = (int)reader["Id"],
                        IdHall = (int)reader["IdHall"],
                        IdUserCoach = (int)reader["IdUserCoach"],
                        DateTime = (DateTime)reader["DateTime"],
                        Description = reader["Description"] as string
                    };
                }
                Logs.Log.Info("All lesson received");

                yield break;
            }
        }

        public Lesson GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetLessonById";

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
                        Logs.Log.Info($"Lesson with - {id} Received");
                        return new Lesson
                        {
                            Id = (int)reader["Id"],
                            IdHall = (int)reader["IdHall"],
                            IdUserCoach = (int)reader["IdUserCoach"],
                            DateTime = (DateTime)reader["DateTime"],
                            Description = reader["Description"] as string
                        };
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
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
                command.CommandText = "dbo.DeleteLesson";

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

                    Logs.Log.Info($"Lesson with Id {id} deleted");
                }
                catch (Exception ex)
                {
                    Logs.Log.Error(ex.Message);
                    throw;
                }
            }
        }

        public void Update(Lesson lesson)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateLesson";

                SqlParameter parameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = lesson.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterId);

                SqlParameter parameterIdUserCoach = new SqlParameter 
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUserCoach",
                    Value = lesson.IdUserCoach,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdUserCoach);

                SqlParameter parameterIdHall = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdHall",
                    Value = lesson.IdHall,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterIdHall);

                SqlParameter parameterDateTime = new SqlParameter
                {
                    DbType = DbType.DateTime2,
                    ParameterName = "@DateTime",
                    Value = lesson.DateTime,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDateTime);

                SqlParameter parameterDescription = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Description",
                    Value = lesson.Description,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameterDescription);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    Logs.Log.Info($"Lesson with Id {lesson.Id} updated");
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
