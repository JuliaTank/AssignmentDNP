using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;
using AssignmentWebAPI.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AssignmentWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (FamilyContext familyContext = new FamilyContext())
            {
                if (!familyContext.Adults.Any())
                {
                    AdultsSeed(familyContext);
                }

                if (!familyContext.Users.Any())
                {
                    UsersSeed(familyContext);
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void AdultsSeed(FamilyContext familyContext)
        {
           string adultsFile = "adults.json";
           IList<Adult> adults;
            if (!File.Exists(adultsFile))
            {
                throw new Exception("File adults.json does not exist");
            }
            else
            {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }

            foreach (var adult in adults)
            {
                familyContext.Adults.Add(adult);
            }

            familyContext.SaveChanges();
        }

        private static void UsersSeed(FamilyContext familyContext)
        {
            string usersFile = "users.json";
            IList<User> users;
            
            if (!File.Exists(usersFile))
            {
                throw new Exception("File users.json does not exist");
            }
            else
            {
                string content = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }

            Console.WriteLine(users[1].ToString());
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
                familyContext.Users.Add(user);
            }

            familyContext.SaveChanges();
        }
    }
    
}