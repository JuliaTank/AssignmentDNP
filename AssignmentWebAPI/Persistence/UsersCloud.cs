

using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;


namespace AssignmentWebAPI.Persistence
{
    public class UsersCloud: IUserService
    {
        public User ValidateUser(string userName, string Password)
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