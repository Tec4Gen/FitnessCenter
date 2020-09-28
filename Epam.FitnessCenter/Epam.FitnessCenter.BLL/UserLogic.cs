using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserLogic _userLogic;

        public UserLogic(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public void Add(User user)
        {
            _userLogic.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userLogic.GetAll();
        }

        public User GetById(int id)
        {
            return _userLogic.GetById(id);
        }

        public void Remove(int id)
        {
            _userLogic.Remove(id);
        }

        public void Update(User user)
        {
            _userLogic.Update();
        }
    }
}
