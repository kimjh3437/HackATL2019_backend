using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackATL_EEVM_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace HackATL_EEVM_backend.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<User> UserList { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Kim",
                    Username = "kimjh3437",

                });
        }
    }
    
}
