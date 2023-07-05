using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Toolkit
{
    class Game
    {
        public static void Main()
        {
            // Setup the menu for the main method
            Console.Clear();
            Console.WriteLine(ToolkitMethods.Menu("Game"));

            // Runt the input menu
            Menu();
        }

        public static void Menu()
        {
            // Runs the command line
            ToolkitMethods.ColorWrite("Console > ", ConsoleColor.DarkCyan);

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "Game");
        }

        // Run the guess the pin game
        public static void PinGuesser()
        {
            Games.PinGuesser.Start();
            Main();
        }
    }
}
