using Epam.FitnessCenter.BLL.Interface;
using Epam.FitnessCenter.Entities;
using Epam.FitnessCenter.Ioc;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = DependenciesResolver.Kernel;

            var a = kernel.Get<IUserLogic>();

            a.Add(new User 
            {
                FirstName = "Ivan",
                LastName = "Martyshin",
                MiddleName = "Alexeevich",
                Login = "Tec4Gen",
                HashPassword = new byte[10],
                RoleWebSite = 1
                
            }, out ICollection<Error> listError);



            Console.ReadLine();
        }
    }
}
