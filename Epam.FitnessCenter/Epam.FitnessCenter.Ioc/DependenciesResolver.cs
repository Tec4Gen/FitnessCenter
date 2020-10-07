using Ninject;

namespace Epam.FitnessCenter.Ioc
{
    public static class DependenciesResolver
    {
        private static NinjectBinds _ninjectBinds = new NinjectBinds();
        public static StandardKernel Kernel= new StandardKernel(_ninjectBinds);

    }
}
