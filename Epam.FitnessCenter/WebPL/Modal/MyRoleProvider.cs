using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Epam.FitnessCenter.BLL;
using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Ioc;
using Ninject;
namespace WebPL.Modal
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IMyRoleProviderLogic myRole = DependenciesResolver.Kernel.Get<MyRoleProviderLogic>();

        public override string[] GetRolesForUser(string username)
        {
            return myRole.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return myRole.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return myRole.IsUserInRole(username, roleName);
        }




        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}