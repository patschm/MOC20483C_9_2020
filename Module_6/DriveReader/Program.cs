using System;
using System.IO;

namespace DriveReader
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo.GetDrives();
            DriveInfo drive = new DriveInfo("E:");
            Console.WriteLine(drive.Name);
            Console.WriteLine("========================");
            ReadDirectories(drive.RootDirectory);
        }

        private static void ReadDirectories(DirectoryInfo directory)
        {
            Console.WriteLine(directory.FullName);
            try
            {
                foreach (FileInfo fi in directory.GetFiles())
                {
                    Console.WriteLine(fi.FullName);
                }
                foreach (DirectoryInfo di in directory.GetDirectories())
                {
                    ReadDirectories(di);
                }
            }
            catch
            {

            }
        }
    }
}
