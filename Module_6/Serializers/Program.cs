using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { FirstName = "Patrick", LastName = "Schmidt", Age = 23 };
            string data = JsonConvert.SerializeObject(p);
            Console.WriteLine(data);
            //Console.WriteLine(p);

            //SerializeBinary(p);
            //DeserializeBinary();

            //SerializeJson(p);
            DeserializeJson();
        }

        private static void DeserializeJson()
        {
            FileStream fs = File.OpenRead(@"E:\person.json");
            StreamReader rdr = new StreamReader(fs);
            
            JsonSerializer ser = new JsonSerializer();

            var p2 = ser.Deserialize(rdr, typeof(Person));
            Console.WriteLine(p2);
        }

        private static void SerializeJson(Person p)
        {
            FileStream fs = File.Create(@"E:\person.json");
            
            StreamWriter sw = new StreamWriter(fs);
            JsonSerializer ser = new JsonSerializer();
            //ser.ContractResolver = new LowerCaseContractResolver();
            ser.Serialize(sw, p);

            sw.Flush();
            fs.Close();
        }

        private static void DeserializeBinary()
        {
            FileStream fs = File.OpenRead(@"E:\person.bin");
            BinaryFormatter bf = new BinaryFormatter();
            var p = bf.Deserialize(fs);
            Console.WriteLine(p);
        }

        private static void SerializeBinary(Person p)
        {
            FileStream fs = File.Create(@"E:\person.bin");

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, p);
            fs.Close();
        }
    }
}
