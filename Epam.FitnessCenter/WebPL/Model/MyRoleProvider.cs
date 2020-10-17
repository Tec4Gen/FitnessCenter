using System;
using System.Web.Security;
using Epam.FitnessCenter.BLL;
using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Ioc;
using Ninject;
namespace WebPL.Model
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private IRoleWebSiteLogic _RoleWebSite = DependenciesResolver.Kernel.Get<RoleWebSiteLogic>();

        private IMyRoleProviderLogic _myRole = DependenciesResolver.Kernel.Get<MyRoleProviderLogic>();
        private IUserLogic _user = DependenciesResolver.Kernel.Get<UserLogic>();

        public override string[] GetRolesForUser(string username)
        {
            var role = _myRole.GetRolesForUser(username);

            if (role == "Admin")
                return new string[] { "Admin", "Trainer", "Client" };
            else if (role == "Trainer")
                return new string[] { "Trainer", "Client" };
            else if (role == "Client")
                return new string[] { "Client" };
            else 
                return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _user.GetByLogin(username);

            var roleUser = _RoleWebSite.GetById(user.RoleWebSite);

            if(roleName == roleUser.Name)
                 return true;
            return false;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
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