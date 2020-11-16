using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentWebAPI.Models;
using AssignmentWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.ObjectPool;

namespace AssignmentWebAPI.Data.Impl
{
    public class SqlTodoService : IPersonService,IUserService
    {
        private FamilyContext context;

        public SqlTodoService(FamilyContext context)
        {
            this.context = context;
        }

        public Adult ValidatePerson(string firstName, string lastName, string sex, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Adult>> GetPersonAsync()
        {
            IList<Adult> adults = await context.Adults.ToListAsync();
            return adults;
        }

        public async Task<Adult> AddPersonAsync(Adult person)
        {
            EntityEntry<Adult> newlyAdded = await context.Adults.AddAsync(person);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemovePersonAsync(int personId)
        {
            context.Remove(await context.Adults.FindAsync(personId));
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync(Adult person)
        {
            throw new System.NotImplementedException();
        }

        //User///////////////////
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            IList<User> users = await context.Users.ToListAsync();
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