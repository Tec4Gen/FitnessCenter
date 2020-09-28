using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;

namespace Epam.FitnessCenter.DAL
{
    public class UsersLessonDao : IUsersLessonDao
    {
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
