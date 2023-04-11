//Created By ThatDevConnor
//TODO:
//Delete subfolder files
//Copy subfolder files

using Console_Toolkit.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Console_Toolkit
{
    class Program
    {
        // Runs at the beginning of the program
        static void Main()
        {
            // Run setups for the managers

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

            // Analyze the input for commands
            List<string> commands = input.Split(' ').ToList();
            if (commands.Count == 0)
            {
                Menu();
            }

            // If no method than run the main
            if (commands.Count == 1)
            {
                commands.Add("Main");
            }

            // Execute the method
            Type type = Type.GetType("Console_Toolkit." + commands[0]);
            if (type != null)
            {
                MethodInfo method = type.GetMethod(commands[1]);

                if (method != null)
                {
                    method.Invoke(null, null);
                } else
                {
                    Console.WriteLine(Help());
                }
            } else
            {
                Console.WriteLine(Help());
            }

            Menu();
        }

        // Returns the help display
        public static string Help()
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

        // Network Menu
        static void Network()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("        NETWORK MENU      ");
            Console.WriteLine("==========================");

            //Runs the command line
            //Console.Write("Directory.{0} >  ", directoryLocation);

            //Gets user input on the acion to take
            string input = Console.ReadLine();

            //if input is 'get' than retrieve computer ip
            if (input == "get")
            {
                //Gets the Computer name
                //computerName = Dns.GetHostName();

                //Stores all ips of computer to access
                //IPAddress[] ipaddress = Dns.GetHostAddresses(computerName);

                //Gets the IPv4
                //foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                //{
                    //ipv4 = ip4.ToString();
                //}

                //Gets the IPv6
                //foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                //{
                //    ipv6 = ip6.ToString();
                //}

                //Runs the IP again
                Thread.Sleep(500);
                Console.Clear();
                //IP();
            }

            //Shows IP
            else if (input == "show")
            {
               // Console.WriteLine("Computer Name: " + computerName + "\nIPv4: " + ipv4 + "\nIPv6: " + ipv6);
                Console.ReadLine();
                //IP();
            }

            //Runs this function again is none command is vaild
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvald Command");
                //IP();
            }
        }

        //Ends process
        static void QuitApplication(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
