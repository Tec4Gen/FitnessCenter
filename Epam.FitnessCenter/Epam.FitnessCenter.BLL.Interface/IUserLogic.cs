﻿using Epam.FitnessCenter.Entities;
using System.Collections.Generic;

namespace Epam.FitnessCenter.BLL.Interface
{
    public interface IUserLogic
    {
        User GetById(int id);

        User GetByLogin(string login);

        void Add(User user, out ICollection<Error> listError);

        void Remove(int id, out ICollection<Error> listError);

        void Update(User user, out ICollection<Error> listError);

        bool Auth(User user);
        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllUserByRole(int id);
    }
}
