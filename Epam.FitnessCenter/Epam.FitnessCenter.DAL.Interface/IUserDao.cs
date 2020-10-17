using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IUserDao
    {
        User GetById(int id);

        User GetByLogin(string login);

        void Add(User user);

        void Remove(int id);

        void Update(User user);

        bool Auth(User user);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllUserByRole(int id);

    }
}
