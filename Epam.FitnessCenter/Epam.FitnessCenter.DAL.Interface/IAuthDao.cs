using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IAuthDao
    {
        bool CanLogin(string login, byte[] password);
    }
}
