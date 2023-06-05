using Console_Toolkit.Files;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Toolkit
{
    internal class File
    {
        public static void Main()
        {
            // Setup the menu for the main method
            Console.Clear();
            Console.WriteLine(ToolkitMethods.Menu("File"));

            // Runt the input menu
            Menu();
        }

        public static void Menu()
        {
            // Runs the command line
            Console.Write("Console >  ");

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "File");
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
