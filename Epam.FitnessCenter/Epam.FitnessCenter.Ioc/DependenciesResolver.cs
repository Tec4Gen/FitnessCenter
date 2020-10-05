
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.Ioc
{
    public class DependenciesResolver
    {
        private static NinjectBinds _ninjectBinds = new NinjectBinds();
        public static StandardKernel Kernel= new StandardKernel(_ninjectBinds);


    }
}
