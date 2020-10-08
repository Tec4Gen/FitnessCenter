using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.DAL.Interface
{
    public interface IMyRoleProviderDao
    {
        string[] GetRolesForUser(string username);

        string[] GetUsersInRole(string roleName);

        bool IsUserInRole(string username, string roleName);
    }
}
