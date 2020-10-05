using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.CustomException
{
    public class RoleUndefinedException: Exception
    {
        public RoleUndefinedException() : base() { }
        public RoleUndefinedException(string message) : base(message) { }
        public RoleUndefinedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
