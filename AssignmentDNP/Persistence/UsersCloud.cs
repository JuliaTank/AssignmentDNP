using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentDNP.Data;
using Models;

namespace AssignmentDNP.Persistence
{
    public class UsersCloud : IUserService
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;

        public UsersCloud()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string username, string password)
            {
                HttpResponseMessage response =
                    await client.GetAsync(uri+$"/users?username={username}&password={password}");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string userAsJson = await response.Content.ReadAsStringAsync();
                    User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                    return resultUser;
                }

                throw new Exception("User not found");
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