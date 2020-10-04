using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface ILessonLogic
    {
        Lesson GetById(int id);

        void Add(Lesson lesson, out IEnumerable<Error> listError);

        void Remove(int id, out IEnumerable<Error> listError);

        void Update(Lesson lesson, out IEnumerable<Error> listError);

        IEnumerable<Lesson> GetAll();
    }
}
