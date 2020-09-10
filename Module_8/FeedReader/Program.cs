using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FeedReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsingWebRequest();
            UsingHttpClient();
            Console.ReadLine();  
        }

        private static async Task UsingHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://nu.nl/");
            var response = await client.GetAsync("rss");
            var str = await response.Content.ReadAsStreamAsync();
            //HandleWithLinqToXml(str);
            HandleWithXmlSerializer(str);
        }

        private static void UsingWebRequest()
        {
            HttpWebRequest req = WebRequest.Create("https://nu.nl/rss") as HttpWebRequest;
            HttpWebResponse response =  req.GetResponse() as HttpWebResponse;
            //HandleWithXmlSerializer(response.GetResponseStream());
            HandleWithLinqToXml(response.GetResponseStream());
        }

        private static void HandleWithLinqToXml(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);

            var query = from item in doc.Descendants("item")
            select new Item
            {
                Category = item.Element("category").Value,
                Title = item.Element("title").Value,
                Description = item.Element("description").Value
            };

            ShowItems(query.ToList());

        }
        private static void HandleWithXmlSerializer(Stream stream)
        {
            List<Item> news = new List<Item>();
            XmlSerializer ser = new XmlSerializer(typeof(Item));
            XmlReader rdr = XmlReader.Create(stream);
            while (rdr.ReadToFollowing("item"))
            {
                XmlReader sub = rdr.ReadSubtree();
                Item ietm = ser.Deserialize(sub) as Item;
                news.Add(ietm);
            }
            ShowItems(news);
        }

        private static void ShowItems(List<Item> news)
        {
            foreach(Item item in news)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.Category);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Title);
                Console.ResetColor();
                Console.WriteLine(item.Description);
                Console.WriteLine("============================================================");
            }
        }
    }
}
