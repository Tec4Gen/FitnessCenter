using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private IAuthDao _authDao;

        public AuthLogic(IAuthDao authDao)
        {
            _authDao = authDao;
        }

        public bool CanLogin(string login, byte[] password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(password);
                password = hashValue;

                return _authDao.CanLogin(login, password);
            }
        }
    }
}
