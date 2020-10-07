using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class RoleWebSiteLogic : IRoleWebSiteLogic
    {
        private IRoleWebSiteDao _roleWebSiteLogic;

        public RoleWebSiteLogic(IRoleWebSiteDao roleWebSiteLogic)
        {
            _roleWebSiteLogic = roleWebSiteLogic;
        }
        public IEnumerable<RoleWebSite> GetAll()
        {
            return _roleWebSiteLogic.GetAll();
        }

        public RoleWebSite GetById(int id)
        {
            return _roleWebSiteLogic.GetById(id);
        }
    }
}
