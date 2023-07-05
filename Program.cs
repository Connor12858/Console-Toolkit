using System;

namespace Console_Toolkit
{
    internal class Program
    {
        // Runs at the beginning of the program
        public static void Main()
        {
            //Initals the parser for running
            Network.Start();
            File.Start();

            // Display inital Menu title
            Console.WriteLine(ToolkitMethods.Menu("Program"));

            // Run the Main Menu
            Menu();
        }

        // Main Menu
        public static void Menu()
        {
            // Runs the command line
            ToolkitMethods.ColorWrite("Console > ", ConsoleColor.DarkCyan);

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "Program");
        }
    }
}
