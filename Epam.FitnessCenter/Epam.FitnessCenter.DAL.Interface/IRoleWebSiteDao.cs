using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IRoleWebSiteDao
    {
        IEnumerable<RoleWebSite> GetAll();

        RoleWebSite GetById(int id);
    }
}
