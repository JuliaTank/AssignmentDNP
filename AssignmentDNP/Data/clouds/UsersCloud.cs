using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Models;

namespace Persistence
{
    public class UsersCloud: IUserService
    {
        HttpClient client = new HttpClient();
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:5004/users?username="+username+"&password="+password);
            
            if(response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                User result = JsonSerializer.Deserialize<User>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
            Console.WriteLine("user received on client side " +response.Content.ReadAsStringAsync().Result);
            //why this exception isn't thrown?
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public Task<IList<User>> GetUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}