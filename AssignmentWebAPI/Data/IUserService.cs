using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;


namespace AssignmentWebAPI.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string Password);
        Task<IList<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
    }
}