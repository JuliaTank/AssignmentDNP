﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Models;

namespace Persistence
{
    public class UsersCloud: IUserService
    {
        public Task<User> ValidateUser(string userName, string Password)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<User>> GetUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}