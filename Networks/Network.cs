using Console_Toolkit.Networks;
using System;
using System.Net.NetworkInformation;
using System.Net;

namespace Console_Toolkit
{
    internal class Network
    {
        public static void Main()
        {
            // Setup the menu for the main method
            Console.Clear();
            ToolkitMethods.Menu("Network");
            Console.WriteLine("Network Main");
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
            if(ifSave != 'n')
            {

            }
            Console.ReadKey();
        }
    }
}
