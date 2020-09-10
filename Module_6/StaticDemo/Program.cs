using System;
using System.IO;

namespace StaticDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StaticDemos();
            InstanceDemos();

        }

        private static void InstanceDemos()
        {
            FileInfo fi = new FileInfo(@"E:\testfile.txt");
            if (!fi.Exists)
            {
                fi.Create().Dispose();
                fi.Attributes = FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.System;
                Console.WriteLine(fi.FullName);
                Console.WriteLine(fi.Attributes);
                Console.WriteLine(fi.CreationTime);
                Console.WriteLine(fi.DirectoryName);
                Console.WriteLine(fi.Extension);
            }
            else
            {
                fi.Delete();
            }
        }

        private static void StaticDemos()
        {
             if (!Directory.Exists(@"E:\TestDir"))
            {
                Directory.CreateDirectory(@"E:\TestDir");
            }
            Directory.Delete(@"E:\TestDir");
        }
    }
}
