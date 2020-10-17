using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL
{
    public class MyRoleProviderLogic: IMyRoleProviderLogic
    {
        private IMyRoleProviderDao _provDao;

        public MyRoleProviderLogic(IMyRoleProviderDao provDao)
        {
            _provDao = provDao;
        }

        public string GetRolesForUser(string username)
        {
            return _provDao.GetRolesForUser(username);
        }
    }
}
