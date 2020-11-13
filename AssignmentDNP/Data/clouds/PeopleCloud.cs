using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Models;

namespace AssignmentDNP.Persistence
{
    public class PeopleCloud: IPersonService 
    {
        HttpClient client = new HttpClient();
        public async Task<Adult> ValidatePersonAsync(string firstName, string lastName, string sex, int id)
        {
            string message = await client.GetStringAsync("https://localhost:5004/adults");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            throw new NotImplementedException();
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            string message = await client.GetStringAsync("https://localhost:5004/adults");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddPersonAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:5004/adults",content);
            Console.WriteLine(response.ToString());
            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task RemovePersonAsync(int personId)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5004/adults?Id="+personId);
            Console.WriteLine(response);
        }

        public async Task UpdateAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync( "https://localhost:5004/adults",content);
            Console.WriteLine(response.ToString()); 
        }
    }
    }
