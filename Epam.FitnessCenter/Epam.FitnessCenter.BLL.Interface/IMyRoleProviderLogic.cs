﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IMyRoleProviderLogic
    {
        string GetRolesForUser(string username);    
    }
}
