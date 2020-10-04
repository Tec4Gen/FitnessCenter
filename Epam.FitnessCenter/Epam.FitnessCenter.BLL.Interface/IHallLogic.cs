using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IHallLogic
    {
        Hall GetById(int id);

        void Add(Hall hall, out IEnumerable<Error> listError);

        void Remove(int id, out IEnumerable<Error> listError);

        IEnumerable<Hall> GetAll();
    }
}
