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

        void Add(User user, out ICollection<Error> listError);

        void Remove(int id, out ICollection<Error> listError);

        void Update(User user, out ICollection<Error> listError);

        IEnumerable<User> GetAll();
    }
}
