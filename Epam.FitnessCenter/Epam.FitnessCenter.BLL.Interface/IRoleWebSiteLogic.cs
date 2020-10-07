using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IRoleWebSiteLogic
    {
        IEnumerable<RoleWebSite> GetAll();

        RoleWebSite GetById(int id);
    }
}
