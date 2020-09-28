using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class UsersLessonLogic : IUsersLessonLogic
    {
        IUsersLessonLogic _usersLessonLogic;

        public UsersLessonLogic(IUsersLessonLogic usersLessonLogic)
        {
            _usersLessonLogic = usersLessonLogic;
        }

        public void Add(Lesson lesson)
        {
            _usersLessonLogic.Add(lesson);
        }

        public IEnumerable<UserLesson> GetAllLessonsByIdUser(int idUser)
        {
            return _usersLessonLogic.GetAllLessonsByIdUser(idUser);
        }

        public IEnumerable<UserLesson> GetAllUsersByIdLesson(int idLesson)
        {
            return _usersLessonLogic.GetAllUsersByIdLesson(idLesson);
        }

        public UserLesson GetById(int id)
        {
            return _usersLessonLogic.GetById(id);
        }

        public void Remove(int id)
        {
            _usersLessonLogic.Remove(id);
        }
    }
}
