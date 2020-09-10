using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Remoting
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoWebRequests();
            DemoHttpClient();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static async Task DemoHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            //handler.Credentials = CredentialCache.DefaultCredentials;
            handler.Credentials = new NetworkCredential("", "");        

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.xs4all.nl/");
            
            var result = await client.GetAsync("");
            Console.WriteLine(result.StatusCode);
            string body = await result.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }

        private static void DemoWebRequests()
        {
            HttpWebRequest req = WebRequest.Create("https://www.xs4all.nl") as HttpWebRequest;
            req.Headers.Add("Accept", "text/html");
            req.Method = "GET";
            //req.Credentials = new NetworkCredential("user", "pass");

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Console.WriteLine(resp.StatusCode);
            Console.WriteLine(resp.Headers["content-type"]);

            Stream str = resp.GetResponseStream();
            StreamReader rdr = new StreamReader(str);
            string result = rdr.ReadToEnd();

            Console.WriteLine(result);

        }
    }
}
