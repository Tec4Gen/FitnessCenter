using Epam.FitnessCenter.CustomException;
using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    //TODO Logger
    public class HallLogic : IHallLogic
    {
        private IHallDao _hallDao;

        public HallLogic(IHallDao hallDao)
        {
            _hallDao = hallDao;
        }

        public void Add(Hall hall, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                _hallDao.Add(hall);
            }
            catch (UniqueIdentifierException ex)
            {
                listError.Add(new Error
                {
                    Message = ex.Message
                });
            }
            catch
            {
                listError.Add(new Error
                {
                    Message = "Failed to add hall, please try again"
                });
            }
        }

        public IEnumerable<Hall> GetAll()
        {
            return _hallDao.GetAll();
        }

        public Hall GetById(int id)
        {
            return _hallDao.GetById(id);
        }

        public void Remove(int id, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            try
            {
                if (_hallDao.GetById(id) == null)
                {
                    listError.Add(new Error
                    {
                        Message = "Hall won't find"
                    });
                    return;
                }
                _hallDao.Remove(id);
            }
            catch
            {
                listError.Add(new Error
                {
                    Message = "Internal error, try again"
                });
            }
        }
    }
}
