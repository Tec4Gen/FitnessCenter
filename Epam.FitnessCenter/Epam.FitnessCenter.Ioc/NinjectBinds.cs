using Epam.FitnessCenter.BLL;
using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.DAL;
using Epam.FitnessCenter.DAL.Interface;
using Ninject.Modules;

namespace Epam.FitnessCenter.Ioc
{
    public class NinjectBinds : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDao>().To<UserDao>();
            Bind<IHallDao>().To<HallDao>();
            Bind<ILessonDao>().To<LessonDao>();
            Bind<IUsersLessonDao>().To<UsersLessonDao>();
            Bind<IRoleWebSiteDao>().To<RoleWebSiteDao>();
            Bind<IMyRoleProviderDao>().To<MyRoleProviderDao>();
            Bind<IAuthDao>().To<AuthDao>();

            Bind<IUserLogic>().To<UserLogic>();
            Bind<IHallLogic>().To<HallLogic>();
            Bind<ILessonLogic>().To<LessonLogic>();
            Bind<IUsersLessonLogic>().To<UsersLessonLogic>();
            Bind<IRoleWebSiteLogic>().To<RoleWebSiteLogic>();
            Bind<IMyRoleProviderLogic>().To<MyRoleProviderLogic>();
            Bind<IAuthLogic>().To<AuthLogic>();
        }
    }
}
