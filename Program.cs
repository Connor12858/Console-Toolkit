//Created By Connor12858

using Console_Toolkit.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;

namespace Console_Toolkit
{
    internal class Program
    {
        // Runs at the beginning of the program
        static void Main()
        {
            // Display inital Menu title
            Console.WriteLine(ToolkitMethods.Menu("menu"));

            // Run the Main Menu
            Menu();
        }

        // Main Menu
        static void Menu()
        {
            // Runs the command line
            Console.Write("Console >  ");

            // Gets user input on the acion to take
            string input = Console.ReadLine();

            // Check for clear command
            if (input.ToLower() == "cls" || input.ToLower() == "clear")
            {
                ToolkitMethods.ClearScreen("menu");
                Menu();
            }

            // Check if the input is empty
            else if (input.Length == 0)
            {
                Menu();
            }

            // Analyze the input for commands
            List<string> commands = input.Split(' ').ToList();

            // Variables to determine the method to call
            // Detect if we need to use the main method or not
            string classType = commands[0];
            string methodName = "Main";
            if (commands.Count >= 2)
            {
                methodName = commands[1];
            }

            // Drop the first 2 items to make it a list of argumens
            commands.Remove(classType);
            commands.Remove(methodName);

            // Create an array from the commands
            object[] args = commands.ToArray();

            // Execute the method
            var method = ToolkitMethods.RetrieveMethod(classType, methodName);
            if (method != null)
            {
                method.Invoke(null, args);
            }
            else
            {
                Console.WriteLine(Help());
            }

            // Runs the menu program again
            Menu();
        }

        // Returns the help display
        private static string Help()
        {
            string helpMenu = "";

            // Reead the menu from a text file
            foreach (string line in FileManager.ReadFromFile("..\\..\\ProgramFiles\\HelpMenu.txt"))
            {
                helpMenu += line + "\n";
            }

            // Return the text
            return helpMenu;
        }

        //Ends process
        static void QuitApplication(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
