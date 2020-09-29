using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Epam.FitnessCenter.DAL
{
    public class UsersLessonDao : IUsersLessonDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FintessCenter"].ConnectionString;
        public void Add(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLesson> GetAllLessonsByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLesson> GetAllUsersByIdLesson(int idLesson)
        {
            throw new NotImplementedException();
        }

        public UserLesson GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
