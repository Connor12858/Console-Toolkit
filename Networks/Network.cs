using Console_Toolkit.Networks;
using System;
using Console_Toolkit.Files;
using Console_Toolkit.ProgramTools;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.IO;

namespace Console_Toolkit
{
    internal class Network
    {
        // All the parsers for access
        private readonly static ArgumentParser parserIPInfo = new ArgumentParser();
        private readonly static ArgumentParser parserIPAddress = new ArgumentParser();  

        // Setup the parsers
        public static void Start()
        {
            parserIPInfo.AddArgument<string>("-ip", "127.0.0.1");

            parserIPAddress.AddArgument<bool>("-s", "false");
            parserIPAddress.AddArgument<bool>("-a", "true");
            parserIPAddress.AddArgument<string>("-p", "C:\\");
        }

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
            ToolkitMethods.ColorWrite("Console > ", ConsoleColor.DarkCyan);

            // Gets user input on the acion to take
            string input = Console.ReadLine();
            ToolkitMethods.CommandEntry(input, "Network");
        }

        public static void IPInfo(string ip)
        {
            // Take the values from the passed args
            Console.WriteLine();
            string[] args = { ip };
            bool parsed = parserIPInfo.BreakdownArgs(args);

            // If it is correctly parsed than we run
            if (parsed)
            {
                // Get the value
                string ipAddress = parserIPInfo.GetArgumentValue("-ip");

                // Check if the IP is online
                if (NetworkManager.IPOnline(ipAddress))
                {
                    Console.WriteLine(ipAddress);
                }
                else
                {
                    Console.WriteLine("IP Address is not online to check");
                }
            }

            // Keep it outputted nice
            Console.WriteLine();
        }

        public static void IPAddress(string a, string b="-s?false", string c="-p?C:\\")
        {
            // Pass the arugments to the method's parser
            Console.WriteLine();
            string[] args = { a, b, c };
            bool parsed = parserIPAddress.BreakdownArgs(args);

            // only if the got parsed correctly
            if (parsed)
            {
                // Create a dictonary to store the results, and save to xml file if called for
                Dictionary<string, string> results = new Dictionary<string, string>();

                // Get the host ip, output, and break for subnet
                string host = NetworkManager.FindIPv4Local(Dns.GetHostAddresses(Dns.GetHostName()));
                Console.WriteLine("Your IP: " + host);
                string subnet = string.Join(".", host.Split('.').Take(3).ToArray());

                Parallel.For(0, 256, (i, loopstate) =>
                {
                    // Create the ip strings
                    string ip = subnet + "." + i.ToString();
                    string ipString = "IP: " + ip;

                    // Output the state of the ip 
                    if (NetworkManager.IPOnline(ip))
                    {
                        ToolkitMethods.ColorWriteLine(new string(' ', 25 - ipString.Length) + "ONLINE", ConsoleColor.Green, ipString);
                        results.Add(ipString.Substring(4), "online");
                    }
                    else
                    {
                        // Check if we should output offline ips
                        if (parserIPAddress.GetArgumentValue("-a"))
                        {
                            ToolkitMethods.ColorWriteLine(new string(' ', 25 - ipString.Length) + "OFFLINE", ConsoleColor.Red, ipString);
                            results.Add(ipString.Substring(4), "offline");
                        }
                    }
                });

                // Check if we save the results to a file
                if (parserIPAddress.GetArgumentValue("-s"))
                {
                    try
                    {
                        // Create the path and file name for the file
                        string folderPath = parserIPAddress.GetArgumentValue("-p");
                        string fileName = FileManager.TimeStamp("IPRecords.txt");
                        string fullPath = FileManager.AddPaths(new string[] { folderPath, fileName });
                        int count = 1;

                        // Checks for duplicates
                        while (FileManager.FileExists(fullPath))
                        {
                            fileName = FileManager.TimeStamp("IPRecords.txt") + " (" + Convert.ToString(count) + ")";
                            count++;
                            fullPath = FileManager.AddPaths(new string[] { folderPath, fileName });
                        }

                        // Tell the user what is happening
                        Console.WriteLine("Saving file at " + fullPath);

                        // Turn the results to a format for the file
                        List<string> fileContents = new List<string>{ "{" };
                        foreach (var result in results)
                        {
                            fileContents.Add($"   [{result.Key}, {result.Value}],");
                        }
                        fileContents.Add("}");

                        // Create the file
                        FileManager.CreateFile(fullPath, fileContents.ToArray());

                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }
            }

            // Adds an empty space for neatness
            Console.WriteLine();
        }
    }
}
