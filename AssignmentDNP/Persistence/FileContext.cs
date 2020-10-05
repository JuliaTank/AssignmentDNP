using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AssignmentDNP.Data;
using Microsoft.AspNetCore.Identity;
using Models;

namespace Persistence {
public class FileContext: IPersonService,IUserService {
    public IList<Adult> Adults { get; private set; }
    public IList<User> Users { get; private set; }

    private readonly string usersFile = "users.json";
    private readonly string adultsFile = "adults.json";
    
    public FileContext() {
       
        Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        
        
    }

    private IList<T> ReadData<T>(string s) {
        using (var jsonReader = File.OpenText(s)) {
            return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
        }
    }

    public void SaveChanges() {
        // storing persons
        string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions {
            WriteIndented = true
        });

        using (StreamWriter outputFile = new StreamWriter(adultsFile, false)) {
            outputFile.Write(jsonAdults);
        }
        //storing users
        string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        using (StreamWriter outputFile = new StreamWriter(usersFile, false))
        {
            outputFile.Write(jsonUsers);
        }
    }


    //@todo change query fields
    public Adult ValidatePerson(string FirstName, string LastName, string sex, int id)
    {
        Adult first = Adults.FirstOrDefault(adult => adult.LastName.Equals(LastName));
        if (first == null)
        {
            throw new Exception("Person not found");
        }

        if (!first.FirstName.Equals(FirstName) || !first.LastName.Equals(LastName) || 
            !first.Sex.Equals(sex) || first.Id !=id)
        {
            throw new Exception("Incorrect data");
        }

        return first;
    }

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

    public IList<Adult> GetAdults()
    {
        List<Adult> tmp = new List<Adult>(Adults);
        return tmp;
    }

    public void AddAdult(Adult adult)
    {
        //@todo check exist database/file
        if (!Adults.Contains(adult))
        {
            int max = Adults.Max(adult => adult.Id);
                    adult.Id = (++max);
                    Adults.Add(adult);
                    string productAsJson = JsonSerializer.Serialize(Adults);
                    File.WriteAllText(adultsFile,productAsJson);
        }
        else
        {
            adult = null;
        }
    }

    public void RemoveAdult(int adultId)
    {
        Adult toRemove = Adults.First(t => t.Id == adultId);
        Adults.Remove(toRemove);
        string productAsJson = JsonSerializer.Serialize(Adults);
        File.WriteAllText(adultsFile, productAsJson);
    }
    
}
}