using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;


namespace AssignmentWebAPI.Persistence
{
    public class PeopleCloud: IPersonService
    {
        HttpClient client = new HttpClient();
        public Adult ValidatePerson(string firstName, string lastName, string sex, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            string message = await client.GetStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<Adult> AddPersonAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync(,content);
            Console.WriteLine(response.ToString()); 
        }

        public async Task RemovePersonAsync(int personId)
        {
            HttpResponseMessage response = await client.DeleteAsync();
            Console.WriteLine(response);
        }

        public async Task UpdateAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync( ,content);
            Console.WriteLine(response.ToString()); 
        }
    }
}