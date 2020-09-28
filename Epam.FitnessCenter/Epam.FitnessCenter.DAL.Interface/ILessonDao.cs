using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface ILessonDao
    {
        Lesson GetById(int id);

        void Add(Lesson lesson);

        void Remove(int id);

        void Update(Lesson lesson);

        IEnumerable<Lesson> GetAll();
    }
}
