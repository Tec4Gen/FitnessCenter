using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
