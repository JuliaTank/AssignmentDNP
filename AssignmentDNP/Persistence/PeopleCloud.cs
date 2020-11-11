using System;
using System.Collections.Generic;
using System.Net;
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
        private string uri = "https://localhost:5001";
        HttpClient client = new HttpClient();
        public async Task<Adult> ValidatePerson(string firstName, string lastName, string sex, int id)
        {
            HttpResponseMessage response = await client.GetAsync(uri+$"/PeopleList?firstName={firstName}&lastName={lastName}&sex={sex}&id=(id)");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string personAsJson = await response.Content.ReadAsStringAsync();
                Adult resultPerson = JsonSerializer.Deserialize<Adult>(personAsJson);
                return resultPerson;
            } 
            throw new Exception("Person not found");
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            string message = await client.GetStringAsync(uri+"/PeopleList");
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddPersonAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync(uri+"/AddPerson",content);
            Console.WriteLine(response.ToString()); 
        }

        public async Task RemovePersonAsync(int personId)
        {
            HttpResponseMessage response = await client.DeleteAsync(uri+"/PeopleList");
            Console.WriteLine(response);
        }

        public async Task UpdateAsync(Adult person)
        {
            string personSerialized = JsonSerializer.Serialize(person);
            StringContent content = new StringContent(personSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PutAsync( uri+"/PeopleList",content);
            Console.WriteLine(response.ToString()); 
        }
    }
    }
