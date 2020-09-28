using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IHallDao
    {
        Hall GetById(int id);

        void Add(Hall hall);

        void Remove(int id);

        IEnumerable<Hall> GetAll();
    }
}
