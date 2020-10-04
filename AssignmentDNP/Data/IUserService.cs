using Models;

namespace AssignmentDNP.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}