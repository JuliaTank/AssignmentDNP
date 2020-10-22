using Models;

namespace AssignmentDNP.Data
{
    public interface IPersonService
    {
        Adult ValidatePerson(string firstName, string lastName, string sex, int id);
    }
}