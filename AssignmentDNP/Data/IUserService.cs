using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AssignmentDNP.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
        Task<IList<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
    }
}