using AssignmentWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebAPI.Data.Impl
{
    public class FamilyContext: DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = Family.db");
        }
    }
}