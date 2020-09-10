using EFBasics.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFBasics
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonHobby>().HasKey("PersonID", "HobbyID");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }
    }
}
