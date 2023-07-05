using Console_Toolkit.Files;
using Console_Toolkit.ProgramTools;
using System;
using System.IO;

namespace Console_Toolkit
{
    internal class File
    {
        // All the parsers for access
        private readonly static ArgumentParser parserPurge = new ArgumentParser();

        // Setup the parsers
        public static void Start()
        {
            //Setup the paser for Purge
            parserPurge.AddArgument<bool>("-d", "true");
            parserPurge.AddArgument<string>("-t", "txt");
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
            ToolkitMethods.ColorWrite("Console > ", ConsoleColor.DarkCyan);

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "File");
        }

        public static void Rename()
        {
            Console.WriteLine("File Rename");
            Console.ReadKey();
        }

        public static void Purge(string p, string d="-d?true", string t="-t?txt")
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
                    // Get the path to the folder
                    string folderPath = parserPurge.GetArgumentValue("-p");
                    bool delete = parserPurge.GetArgumentValue("-d");
                    string type = "." + parserPurge.GetArgumentValue("-t");

                    // Check if we delete everything or just a file type
                    if (delete)
                    {
                        // Tell the user
                        Console.WriteLine($"Deleting all files in '{folderPath}'...");

                        // Get the directory
                        DirectoryInfo di = new DirectoryInfo(folderPath);

                        // Remove all the base sales - uses recursion to delete sub folders
                        int count = FileManager.DeleteFolderFiles(di, ".*");
                        Console.WriteLine($"Deleted {count} files");
                    }
                    else
                    {
                        Console.WriteLine($"Deleting all files in '{folderPath}' that have a {type} extension...");

                        // Get the directory
                        DirectoryInfo di = new DirectoryInfo(folderPath);

                        // Remove all the base sales - uses recursion to delete sub folders
                        int count = FileManager.DeleteFolderFiles(di, type);
                        Console.WriteLine($"Deleted {count} files");
                    }
                } catch (Exception e) { Console.WriteLine(e.Message); }
            }

            Console.WriteLine();
        }
    }   
}
