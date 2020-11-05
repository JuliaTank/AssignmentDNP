using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;

namespace AssignmentWebAPI.Data.Impl
{
    public class UserService : IUserService
    {
        private string userFile = "users.json";
        private IList<User> users;

        public UserService()
        {
            if (!File.Exists(userFile))
            {
                Seed();
               WriteUsersToFile();
            }
            else
            {
                string content = File.ReadAllText(userFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
                
            }
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            foreach (var user in users)
            { 
                if (user.UserName.Equals(username))
                {
                    if (user.Password.Equals(password))
                    {
                        Console.WriteLine("valid username and password "+username);
                        return user;
                    }
                    throw new DataException("Wrong password");
                }
            }
            throw new DataException("Username does not exist");
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            List<User> tmp = new List<User>();
            tmp = users.ToList();
            return tmp;
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (users.Contains(user))
            {
                throw new DataException("Username already exists");
            }
            int max = users.Max(user => user.ID);
            user.ID = (++max);
            users.Add(user);
            WriteUsersToFile();
            return user;
        }
        private void WriteUsersToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(userFile, productsAsJson);
        }
        private void Seed()
        {
            User[] tmp =
            {
                new User
                {
                    UserName = "Julia",
                    Password = "8080"
                },
                new User
                {
                    UserName = "Tosia",
                    Password = "1111"
                }
            };
            users = tmp.ToList();
        }
    }
}