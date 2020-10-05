using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface ILessonLogic
    {
        Lesson GetById(int id);

        void Add(Lesson lesson, out ICollection<Error> listError);

        void Remove(int id, out ICollection<Error> listError);

        void Update(Lesson lesson, out ICollection<Error> listError);

        IEnumerable<Lesson> GetAll();
    }
}
