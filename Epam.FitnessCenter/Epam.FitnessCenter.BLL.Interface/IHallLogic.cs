using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IHallLogic
    {
        Hall GetById(int id);

        void Add(Hall hall, out ICollection<Error> listError);

        void Remove(int id, out ICollection<Error> listError);

        IEnumerable<Hall> GetAll();
    }
}
