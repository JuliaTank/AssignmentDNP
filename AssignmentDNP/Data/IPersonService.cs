using Models;

namespace AssignmentDNP.Data
{
    public interface IPersonService
    {
        Adult ValidatePerson(string FirstName, string LastName, string sex, int id);
    }
}