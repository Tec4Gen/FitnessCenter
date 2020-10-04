using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.CustomException;
using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Epam.FitnessCenter.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;

        public UserLogic(IUserDao userLogic)
        {
            _userDao = userLogic;
        }

        public void Add(User user, out ICollection<Error> listError)
        {
            listError = new List<Error>();

            try
            {
                _userDao.Add(user);
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
                    Message = "User not added, internal error occurred, please try again"
                }); ;
            }

        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public void Remove(int id, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            _userDao.Remove(id);
        }

        public void Update(User user, out ICollection<Error> listError)
        {
            listError = new List<Error>();
            _userDao.Update(user);
        }
    }
}
