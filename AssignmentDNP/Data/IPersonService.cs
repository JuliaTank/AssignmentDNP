using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AssignmentDNP.Data
{
    public interface IPersonService
    {
        Task<Adult> ValidatePersonAsync(string firstName, string lastName, string sex, int id);
        Task<IList<Adult>> GetPersonAsync();
        Task   AddPersonAsync(Adult person);
        Task   RemovePersonAsync(int personId);
        Task   UpdateAsync(Adult person);
    }
}