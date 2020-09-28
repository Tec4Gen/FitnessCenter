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
        UserLesson GetById(int id);

        void Add(Lesson lesson);

        void Remove(int id);

        IEnumerable<UserLesson> GetAllLessonsByIdUser(int idUser);

        IEnumerable<UserLesson> GetAllUsersByIdLesson(int idLesson);
    }
}
