using EFBasics.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFBasics
{
    class Program
    {
        private static string conStr = @"Server=.\sqlexpress;Database=PeopleDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

        static void Main(string[] args)
        {
            //InitalizeDatabase();
            //Insert();
            //Modify();
            //Delete();


            //LinqToObjects();

            Read();
        }

        private static void LinqToObjects()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { ID = 1, FirstName = "aaaa", LastName = "AAAA", Age = 23 });
            people.Add(new Person { ID = 2, FirstName = "bbbb", LastName = "BBBB", Age = 23 });
            people.Add(new Person { ID = 3, FirstName = "cccc", LastName = "CCCC", Age = 23 });
            people.Add(new Person { ID = 4, FirstName = "dddd", LastName = "DDDD", Age = 23 });
            people.Add(new Person { ID = 5, FirstName = "eeee", LastName = "EEEE", Age = 23 });

            // Extension variant
            var query = people.OrderByDescending(p => p.FirstName).Skip(2).Take(2);
            var query2= people.Select(p => new  { First = p.FirstName, Last = p.LastName });

            // Language integrated variant
            // Limited with functionality
            var query3 = from p in people orderby p.LastName descending select new { First = p.FirstName, Last = p.LastName };

            //Console.WriteLine(people.Sum(p=>p.Age));

            foreach (var p in query3.Skip(2))
            {
                Console.WriteLine(p.First);
            }

            //bool FindPerson1(Person p)
            //{
            //    return p.ID == 1;
            //}
            //string OrderDescByFN(Person p)
            //{
            //    return p.FirstName;
            //}
        }

        private static void Read()
        {
            DbContextOptionsBuilder<PeopleContext> bld = new DbContextOptionsBuilder<PeopleContext>();
            bld.UseSqlServer(conStr);
            PeopleContext ctx = new PeopleContext(bld.Options);

            // Eager loading (Include)
            var query = ctx.People
                .Include(px=>px.Hobbies)
                    .ThenInclude(ph1=>ph1.Hobby)
                .Where(p => p.ID == 3);

            foreach(Person p1 in query)
            {
                Console.WriteLine($"{p1.FirstName} {p1.LastName}");
                // Explicit Loading
                //ctx.Entry(p1).Collection(px => px.Hobbies).Load();
                foreach(PersonHobby ph in p1.Hobbies)
                {
                    //ctx.Entry(ph).Reference(px => px.Hobby).Load();
                    Console.WriteLine($"\t{ph.Hobby.Description}");
                }
            }

        }

        private static void Delete()
        {
            DbContextOptionsBuilder<PeopleContext> bld = new DbContextOptionsBuilder<PeopleContext>();
            bld.UseSqlServer(conStr);
            PeopleContext ctx = new PeopleContext(bld.Options);
            Person p = ctx.People.Find(2);
            ctx.Remove(p);

            ctx.SaveChanges();

        }

        private static void Modify()
        {
            DbContextOptionsBuilder<PeopleContext> bld = new DbContextOptionsBuilder<PeopleContext>();
            bld.UseSqlServer(conStr);
            PeopleContext ctx = new PeopleContext(bld.Options);

            Person p = ctx.People.Find(2);
            p.FirstName = "Kajsa";

            ctx.SaveChanges();
        }

        private static void Insert()
        {
            DbContextOptionsBuilder<PeopleContext> bld = new DbContextOptionsBuilder<PeopleContext>();
            bld.UseSqlServer(conStr);
            PeopleContext ctx = new PeopleContext(bld.Options);

            Person p1 = new Person { Age = 42, FirstName = "Jan", LastName = "Finkers" };
            Person p2 = new Person { Age = 54, FirstName = "Karin", LastName = "Ollongren" };
            Person p3 = new Person { Age = 52, FirstName = "Pieter", LastName = "Baan" };

            Hobby h1 = new Hobby { Description = "Zeilen" };
            Hobby h2 = new Hobby { Description = "Schaken" };
            Hobby h3 = new Hobby { Description = "Politiek" };
            Hobby h4 = new Hobby { Description = "Sigarenbandjes" };

            ctx.PersonHobbies.Add(new PersonHobby { Person = p1, Hobby = h1 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p1, Hobby = h3 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p2, Hobby = h3 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p2, Hobby = h2 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p3, Hobby = h4 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p3, Hobby = h2 });
            ctx.PersonHobbies.Add(new PersonHobby { Person = p3, Hobby = h1 });

            // Now the data really goes to the database
            ctx.SaveChanges();

        }

        private static void InitalizeDatabase()
        {
            DbContextOptionsBuilder<PeopleContext> bld = new DbContextOptionsBuilder<PeopleContext>();
            bld.UseSqlServer(conStr);
            DbContextOptions options = bld.Options;

            PeopleContext ctx = new PeopleContext(options);
            ctx.Database.EnsureCreated();
        }
    }
}
