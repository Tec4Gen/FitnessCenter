using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IUsersLessonDao
    {
        UsersLesson GetById(int id);

        void Add(UsersLesson lesson);

        void Remove(int id);

        IEnumerable<UsersLesson> GetAllLessonsByIdUser(int idUser);

        IEnumerable<UsersLesson> GetAllUsersByIdLesson(int idLesson);
    }
}
