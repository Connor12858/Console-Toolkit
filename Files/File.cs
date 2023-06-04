using Console_Toolkit.Files;
using System;

namespace Console_Toolkit
{
    internal class File
    {
        public static void Main()
        {
            ToolkitMethods.Menu("File Manager");
            Console.ReadKey();
        }

        public static void Rename()
        {
            Console.WriteLine("File Rename");
            Console.ReadKey();
        }

        public static void Purge(bool deleteAll = true, string fileType = ".txt")
        {
            Console.WriteLine("File Purge");
            Console.ReadKey();
        }
    }
}
