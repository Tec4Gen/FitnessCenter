using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL
{
    public class RoleWebSiteLogic : IRoleWebSiteLogic
    {
        private IRoleWebSiteLogic _roleWebSiteLogic;

        public RoleWebSiteLogic(IRoleWebSiteLogic roleWebSiteLogic)
        {
            _roleWebSiteLogic = roleWebSiteLogic;
        }
        public IEnumerable<RoleWebSite> GetAll()
        {
            return _roleWebSiteLogic.GetAll();
        }
    }
}
