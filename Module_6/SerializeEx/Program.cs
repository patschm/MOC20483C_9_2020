using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SerializeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Person> people = CreatePeople();

            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));

            //FileStream fs = File.Create(@"E:\people.xml");
            //ser.Serialize(fs, people);

            FileStream fs = File.OpenRead(@"E:\people.xml");
            List<Person> pps = ser.Deserialize(fs) as List<Person>;

            foreach (var p in pps)
            {
                Console.WriteLine(p);
            }
        }

        private static List<Person> CreatePeople()
        {
            return Builder<Person>.CreateListOfSize(100).All()
                .With(p => p.FirstName = Faker.Name.First())
                .With(p => p.LastName = Faker.Name.Last())
                .With(p => p.Age = Faker.RandomNumber.Next(0, 123))
                .Build()
                .ToList();
        }
    }
}
