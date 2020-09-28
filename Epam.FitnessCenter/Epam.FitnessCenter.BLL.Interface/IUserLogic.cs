using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IUserLogic
    {
        User GetById(int id);

        void Add(User user);

        void Remove(int id);

        void Update(User user);

        IEnumerable<User> GetAll();
    }
}
