// Created By Connor12858

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
        public static void Main()
        {   
            // Display inital Menu title
            Console.WriteLine(ToolkitMethods.Menu("Program"));

            // Run the Main Menu
            Menu();
        }

        // Main Menu
        public static void Menu()
        {
            // Runs the command line
            Console.Write("Console >  ");

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "Program");
        }

        //Ends process
        static void QuitApplication(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
