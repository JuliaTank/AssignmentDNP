using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AssignmentDNP.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
        Task<IList<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
    }
}