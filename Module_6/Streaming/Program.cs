using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteToStream();
            //ReadFromStream();

            //WriteElegant();
            //ReadElegant();

            //WriteZipped();
            ReadZipped();
            
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void ReadZipped()
        {
            FileStream fs = File.OpenRead(@"E:\hellos.zip");
            GZipStream gzip = new GZipStream(fs, CompressionMode.Decompress);
            StreamReader rdr = new StreamReader(gzip);
            string line = null;
            while ((line = rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        private static void WriteZipped()
        {
            FileStream fs = File.Create(@"E:\hellos.zip");
            GZipStream gzip = new GZipStream(fs, CompressionMode.Compress);
            StreamWriter writer = new StreamWriter(gzip);
            for (int i = 0; i < 1000; i++)
            {
                string data = $"Hello World {i}\n";
                writer.Write(data);
            }
            writer.Flush();
            fs.Close();
        }

        private static void ReadElegant()
        {
            FileStream fs = File.OpenRead(@"E:\hellos2.txt");
            StreamReader rdr = new StreamReader(fs);
            string line = null;
            while ((line = rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        private static void WriteElegant()
        {
            FileStream fs = File.Create(@"E:\hellos2.txt");
            StreamWriter writer = new StreamWriter(fs);
            for (int i = 0; i < 1000; i++)
            {
                string data = $"Hello World {i}\n";
                writer.Write(data);
            }
            writer.Flush();
            fs.Close();
        }

        private static void ReadFromStream()
        {
            FileStream fs = File.OpenRead(@"E:\hellos.txt");

            byte[] buffer = new byte[16];

            int nr = fs.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer);
            Console.Write(data);
            while (nr > 0)
            {
                Array.Clear(buffer, 0, buffer.Length);
                nr = fs.Read(buffer, 0, buffer.Length);
                data = Encoding.UTF8.GetString(buffer);
                Console.Write(data);
            }
        }

        private static void WriteToStream()
        {
            FileStream fs = File.Create(@"E:\hellos.txt");
            for(int i = 0; i < 1000; i++)
            {
                string data = $"Hello World {i}\n";
                byte[] buffer = Encoding.UTF8.GetBytes(data);

                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Close();
        }
    }
}
