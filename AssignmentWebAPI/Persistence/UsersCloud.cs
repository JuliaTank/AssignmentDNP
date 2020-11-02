using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using AssignmentWebAPI.Data;
using AssignmentWebAPI.Models;


namespace Persistence
{
    public class UsersCloud: IUserService
    {
        HttpClient client = new HttpClient();
        public IList<User> Users { get; private set; }
        public User ValidateUser(string userName, string Password)
        {
            User first = Users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }
        
            if (!first.Password.Equals(Password)) {
                throw new Exception("Incorrect password");
            }
        
            return first;
        }
        
        public async Task<User> AddUserAsync(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(userSerialized,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001",content);
            Console.WriteLine(response.ToString());
            return user;
        }
    }
}