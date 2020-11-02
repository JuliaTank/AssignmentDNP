using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Models;

namespace AssignmentDNP.Persistence
{
    public class PeopleCloud: IPersonService //LINKS!!!!!!!!!!!
    {
        HttpClient client = new HttpClient();
        public Adult ValidatePerson(string firstName, string lastName, string sex, int id)
        {
            
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            string message = await client.GetStringAsync("https://localhost:5001/PeopleList");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddPersonAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/AddPerson",content);
            Console.WriteLine(response.ToString()); 
        }

        public async Task RemovePersonAsync(int personId)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/PeopleList");
            Console.WriteLine(response);
        }

        public async Task UpdateAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync( "https://localhost:5001/PeopleList",content);
            Console.WriteLine(response.ToString()); 
        }
    }
    }
