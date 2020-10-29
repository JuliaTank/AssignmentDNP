using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;


namespace AssignmentWebAPI.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
        Task<IList<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
    }
}