using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;


namespace AssignmentWebAPI.Data
{
    public interface IPersonService
    {
        Adult ValidatePerson(string firstName, string lastName, string sex, int id);
        Task<IList<Adult>> GetPersonAsync();
        Task<Adult>  AddPersonAsync(Adult person);
        Task   RemovePersonAsync(int personId);
        Task   UpdateAsync(Adult person);
    }
}