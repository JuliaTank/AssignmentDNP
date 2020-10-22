using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AssignmentDNP.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    
    public Adult ValidatePerson(string firstName, string lastName, string sex, int id)
    {
        //Adult first = Adults.FirstOrDefault(adult => adult.Id==id);
        
        /*if (first == null)
        {*/
            if (firstName == null || firstName.Equals(""))
            {
                throw new Exception("Please specify the first name");
            }

            if (lastName == null || lastName.Equals(""))
            {
                throw new Exception("Please specify last name");
            }

            if (sex == null || !(sex.Equals("F") || sex.Equals("M") || sex.Equals("Other") || sex.Equals("other")))
            {
                throw new Exception("Sex has to be specified as: 'F', 'M' or 'Other'");
            }

            return null;
       // }

        /*
        if (first !=null)
        {
            Console.WriteLine(first.FirstName);
            throw new Exception("Person already exists,");
        }
        */
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
            throw new Exception("User already exists");
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