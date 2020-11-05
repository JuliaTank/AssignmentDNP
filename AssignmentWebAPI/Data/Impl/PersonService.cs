using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;

namespace AssignmentWebAPI.Data.Impl
{
    public class PersonService : IPersonService
    {
        private string adultsFile = "adults.json";
        private IList<Adult> adults;

        public PersonService()
        {
            if (!File.Exists(adultsFile))
            {
                throw new Exception("File adults.json does not exist");
            }
            else
            {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public Adult ValidatePerson(string firstName, string lastName, string sex, int id)
        {
            if (sex.Equals("M") || sex.Equals("F") || sex.Equals("f") || sex.Equals("m"))
            {
                throw new DataException("sex has to be defined by 'F' or 'M'");
            }
            return new Adult
            {
                FirstName =  firstName,
                LastName = lastName,
                Sex = sex,
                Id = id
            };
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            List<Adult> tmp = new List<Adult>();
            tmp = adults.ToList();
            return tmp;
        }

        public async Task<Adult> AddPersonAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
            return adult;
        }

        public async Task RemovePersonAsync(int personId)
        {
            Adult toRemove = adults.First(t => t.Id == personId);
            adults.Remove(toRemove);
            string productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultsFile,productsAsJson);
        }

        public async Task UpdateAsync(Adult person)
        {
            Adult toUpdate = adults.First(t => t.Id == person.Id);
            toUpdate = person;
            toUpdate.JobTitle = person.JobTitle;
            WriteAdultsToFile();
        }
        
        private void WriteAdultsToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultsFile, productsAsJson);
        }
    }
}