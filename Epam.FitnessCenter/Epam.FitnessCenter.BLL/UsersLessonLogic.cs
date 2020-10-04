using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class UsersLessonLogic : IUsersLessonLogic
    {
        IUsersLessonDao _usersLessonDao;

        public UsersLessonLogic(IUsersLessonDao usersLessonLogic)
        {
            _usersLessonDao = usersLessonLogic;
        }

        public void Add(UsersLesson lesson, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            _usersLessonDao.Add(lesson);
        }

        public IEnumerable<UsersLesson> GetAllLessonsByIdUser(int idUser)
        {
            return _usersLessonDao.GetAllLessonsByIdUser(idUser);
        }

        public IEnumerable<UsersLesson> GetAllUsersByIdLesson(int idLesson)
        {
            return _usersLessonDao.GetAllUsersByIdLesson(idLesson);
        }

        public UsersLesson GetById(int id)
        {
            return _usersLessonDao.GetById(id);
        }

        public void Remove(int id, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            _usersLessonDao.Remove(id);
        }
    }
}
