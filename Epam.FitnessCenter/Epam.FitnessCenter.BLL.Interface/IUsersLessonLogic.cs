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

        void Add(Lesson lesson);

        void Remove(int id);

        IEnumerable<UsersLesson> GetAllLessonsByIdUser(int idUser);

        IEnumerable<UsersLesson> GetAllUsersByIdLesson(int idLesson);
    }
}
