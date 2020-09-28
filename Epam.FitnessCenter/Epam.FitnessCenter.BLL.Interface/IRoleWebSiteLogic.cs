using Epam.FitnessCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IRoleWebSiteLogic
    {
        IEnumerable<RoleWebSite> GetAll();
    }
}
