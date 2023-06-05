using Console_Toolkit.Networks;
using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Console_Toolkit.Files;
using Console_Toolkit.ProgramTools;

namespace Console_Toolkit
{
    internal class Network
    {
        public static void Main()
        {
            // Setup the menu for the main method
            Console.Clear();
            Console.WriteLine(ToolkitMethods.Menu("Network"));

            // Runt the input menu
            Menu();
        }

        public static void Menu()
        {
            // Runs the command line
            Console.Write("Console >  ");

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "Network");
        }

        public static void IPInfo(string arg)
        {
            // Setup the arugment parser for this method
            ArgumentParser parser = new ArgumentParser();

            // Add the arguments
            parser.AddArgument<string>("-ip", "127.0.0.1");

            // Take the values from the passed args
            parser.BreakdownArgs(arg);

            // Get the value
            string ipAddress = parser.GetArgumentValue("-ip");

            Console.WriteLine(ipAddress);
            Console.ReadKey();
        }

        public static void IPAddress(string args)
        {
            for (int i = 0; i < 256; i++)
            {
                string ip = "10.0.0." + i.ToString();
                if (NetworkManager.IPOnline(ip))
                {
                    Console.WriteLine("IP: " + ip);
                }
            }
            Console.WriteLine("Save information? (Y/n)");
            char ifSave = Console.ReadKey().KeyChar;
            if (ifSave != 'n' || ifSave != 'N')
            {

            }
            Console.ReadKey();
        }

        private static string Help()
        {
            string helpMenu = "";
            string[] lines = FileManager.ReadFromFile(ProgramCommonVariables.HelpFilePath);


            // Reead the menu from a text file
            for (int i = 0; i < FileManager.LineCount("..\\..\\ProgramFiles\\HelpMenu.txt"); i++)
            {
                if(i != 2 && i != 3 && i != 5 && i != 6 && i != 4)
                {
                    helpMenu += lines[i] + "\n";
                }
            }

            // Return the text
            return helpMenu;

        }
    }
}
