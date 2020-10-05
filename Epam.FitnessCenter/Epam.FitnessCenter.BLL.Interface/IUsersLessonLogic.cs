using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IUsersLessonLogic
    {
        UsersLesson GetById(int id);

        void Add(UsersLesson lesson, out ICollection<Error> listError);

        void Remove(int id, out ICollection<Error> listError);

        IEnumerable<UsersLesson> GetAllLessonsByIdUser(int idUser);

        IEnumerable<UsersLesson> GetAllUsersByIdLesson(int idLesson);
    }
}
