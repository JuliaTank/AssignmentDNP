using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Microsoft.AspNetCore.Http;
using Models;

namespace AssignmentDNP.Persistence
{
    public class UsersCloud : IUserService
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;
        private string userFile = "users.json";

        public UsersCloud()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            HttpResponseMessage response =
                await client.GetAsync(uri + $"/users?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            throw new Exception("User not found");
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            string message = await client.GetStringAsync(userFile);
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;
        }

        public async Task<User> AddUserAsync(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(userSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(userFile, content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            throw new Exception("User cannot be added");
        }
    }
}