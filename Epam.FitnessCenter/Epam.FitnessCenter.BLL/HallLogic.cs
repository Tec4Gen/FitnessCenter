using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public class HallLogic : IHallLogic
    {
        private IHallDao _hallDao;

        public HallLogic(IHallDao hallDao)
        {
            _hallDao = hallDao;
        }

        public void Add(Hall hall, out IEnumerable<Error> listError)
        {
            listError = new List<Error>();
            _hallDao.Add(hall);
        }

        public IEnumerable<Hall> GetAll()
        {
            return _hallDao.GetAll();
        }

        public Hall GetById(int id)
        {
            return _hallDao.GetById(id);
        }

        public void Remove(int id, out IEnumerable<Error> listError)
        {
            listError = new List<Error>();
            _hallDao.Remove(id);
        }
    }
}
