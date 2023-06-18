using Console_Toolkit.Files;
using Console_Toolkit.ProgramTools;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Console_Toolkit
{
    internal class File
    {
        // All the parsers for access
        private static ArgumentParser parserPurge = new ArgumentParser();

        // Setup the parsers
        public static void Start()
        {
            //Setup the paser for Purge
            parserPurge.AddArgument<bool>("-d", "true");
            parserPurge.AddArgument<string>("-f", "txt");
            parserPurge.AddArgument<string>("-p", @"path\to\the\folder");
        }

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

        public static void Purge(string p, string d, string t="txt")
        {
            // Take the values from the passed args
            Console.WriteLine();
            string[] args = { p, d, t };
            bool parsed = parserPurge.BreakdownArgs(args);

            // Run if parsed correctly
            if (parsed)
            {
                try
                {
                    Console.WriteLine(parserPurge.GetArgumentValue("-p"));
                    // Get the path to the folder
                    string folderPath = Environment.GetFolderPath(parserPurge.GetArgumentValue("-p"));

                    // Check if we delete everything or just a file type
                    if (parserPurge.GetArgumentValue("-d"))
                    {
                        Console.WriteLine("Delete All");
                    }
                    else
                    {

                        Console.WriteLine("Delete " + parserPurge.GetArgumentValue("-t"));
                    }
                } catch (Exception e) { Console.WriteLine("Not a valid File Path"); }
            }

            Console.WriteLine();
        }
    }   
}
