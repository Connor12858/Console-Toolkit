using Console_Toolkit.Files;
using Console_Toolkit.ProgramTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Console_Toolkit
{
    internal class File
    {
        // All the parsers for access
        private readonly static ArgumentParser parserPurge = new ArgumentParser();
        private readonly static ArgumentParser parserRename = new ArgumentParser();

        // Setup the parsers
        public static void Start()
        {
            //Setup the paser for Purge
            parserPurge.AddArgument<bool>("-d", "true");
            parserPurge.AddArgument<string>("-t", "txt");
            parserPurge.AddArgument<string>("-p", @"path\to\the\folder");

            parserRename.AddArgument<string>("-p", @"path\to\the\folder");
            parserRename.AddArgument<string>("-f", "time");
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

        public static void Rename(string p, string f = "-f?time")
        {
            // Take the values from the passed args
            Console.WriteLine();
            string[] args = { p, f };
            bool parsed = parserRename.BreakdownArgs(args);

            // Only if correctly parsed should we run
            if (parsed)
            {
                try
                {
                    // Get the information
                    string folderPath = parserRename.GetArgumentValue("-p");
                    string format = parserRename.GetArgumentValue("-f");

                    // Make it easy to look, ignoring the capitalization
                    format = format.ToLower();

                    // Get the directory
                    DirectoryInfo dir = new DirectoryInfo(folderPath);

                    // Check which format to use for the mass rename
                    switch (format)
                    {
                        // Based on the creation date of the file we are renaming it to that
                        case "time":

                            // Loop for each file
                            foreach (FileInfo file in FileManager.AllFilesInFolder(dir))
                            {
                                // Get all the information of the file
                                Dictionary<string, string> fileInfo = FileManager.FileInformation(file);

                                // Generate the new name of the file with a timestamp instead
                                string new_name = fileInfo["Creation Time"];

                                // Format to be a vaild file name
                                new_name = new_name.Replace('/', '-').Replace(' ', '_').Replace(':', '.');

                                // Only if the name hasn't been already formatted
                                Console.WriteLine(new_name + " " + fileInfo["Path"]);
                                if (!fileInfo["Path"].Contains(new_name))
                                {
                                    // Add the path
                                    new_name = fileInfo["Path"].Replace(fileInfo["Name"], new_name);
                                    new_name += fileInfo["Extension"];

                                    // If the file name already is there add/replace a number
                                    int fileCount = 1;
                                    while (FileManager.FileExists(new_name))
                                    {
                                        if (new_name.Contains($" ({fileCount - 1})"))
                                        {
                                            // Replace the tag with the next number
                                            new_name = new_name.Replace($" ({fileCount - 1})", $" ({fileCount})");
                                        }
                                        else
                                        {
                                            // Add a tag with the next file name
                                            new_name = new_name.Replace(fileInfo["Extension"], $" ({fileCount})" + fileInfo["Extension"]);
                                        }
                                        fileCount++;
                                    }

                                    // Rename the file by moving the contents to the new path
                                    Console.WriteLine(new_name);
                                    file.MoveTo(new_name);
                                }
                            }

                            break;

                        // Number them from 1 till all files renamed numbered
                        case "number":

                            // Create the count we use to number them
                            int nameCount = 1;

                            // Loop for each file
                            foreach (FileInfo file in FileManager.AllFilesInFolder(dir))
                            {
                                // Get all the information of the file
                                Dictionary<string, string> fileInfo = FileManager.FileInformation(file);

                                // Create a new name with the count
                                string new_name = fileInfo["Path"].Replace(fileInfo["Name"], nameCount.ToString());
                                new_name += fileInfo["Extension"];

                                // If it exsists we need to add 1 and skip it
                                while(System.IO.File.Exists(new_name))
                                {
                                    // Increase the count
                                    nameCount++;

                                    // Recreate the name of the file
                                    new_name = fileInfo["Path"].Replace(fileInfo["Name"], nameCount.ToString());
                                    new_name += fileInfo["Extension"];
                                }

                                // Tell the user the new path
                                Console.WriteLine(new_name);

                                // Rename the file by moving the contents to the new path
                                file.MoveTo(new_name);
                            }

                            break;

                        // None of them matched which means it is not a supported value
                        default:
                            throw new Exception("Incorrect format was given");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            Console.WriteLine();
        }

        public static void Purge(string p, string d = "-d?true", string t = "-t?txt")
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

                    // Get the directory
                    DirectoryInfo di = new DirectoryInfo(folderPath);

                    // Check if we delete everything or just a file type
                    if (delete)
                    {
                        // Tell the user
                        Console.WriteLine($"Deleting all files in '{folderPath}'...");

                        // Remove all the base sales - uses recursion to delete sub folders
                        int count = FileManager.DeleteFolderFiles(di, ".*");
                        Console.WriteLine($"Deleted {count} files");
                    }
                    else
                    {
                        Console.WriteLine($"Deleting all files in '{folderPath}' that have a {type} extension...");

                        // Remove all the base sales - uses recursion to delete sub folders
                        int count = FileManager.DeleteFolderFiles(di, type);
                        Console.WriteLine($"Deleted {count} files");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            Console.WriteLine();
        }
    }
}
