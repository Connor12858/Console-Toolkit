using Console_Toolkit.Networks;
using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Console_Toolkit.Files;

namespace Console_Toolkit
{
    internal class Network
    {
        public static void Main()
        {
            // Setup the menu for the main method
            Console.Clear();
            Console.WriteLine(ToolkitMethods.Menu("Network"));

            // Runs the command line
            Console.Write("Console >  ");

            // Gets user input on the acion to take
            string input = Console.ReadLine();

            // Check for clear command
            if (input.ToLower() == "cls" || input.ToLower() == "clear")
            {
                ToolkitMethods.ClearScreen("Network");
                Main();
            }

            // Check if the input is empty
            else if (input.Length == 0)
            {
                Main();
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
                Console.WriteLine(ToolkitMethods.Help("Network"));
            }

            Console.ReadKey();
        }

        public static void IPInfo(string args = "127.0.0.1")
        {
            Console.WriteLine("Network IPInfo");
            Console.ReadKey();
        }

        public static void IPAddress(bool retrunMenu = true)
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
