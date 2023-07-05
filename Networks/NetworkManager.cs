using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Console_Toolkit.Networks
{
    internal class NetworkManager
    {
        // Finds if an IP is online
        public static bool IPOnline(string ip)
        {
            try
            {
                // Create objects for checking
                Ping ping;
                PingReply pingReply;

                // Send a ping to the computer
                ping = new Ping();
                pingReply = ping.Send(ip);

                // Check if the ping was success (online)
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                // None of it applies its offline
                else
                {
                    return false;
                }
            } catch
            {
                return false;
            }
        }

        public static string FindIPv4Local(IPAddress[] ips)
        {
            // Check each IP
            foreach (IPAddress ip in ips)
            {
                // The family matchs v4
                if (ip.ToString().Split('.')[0] == "10")
                {
                    // return the ip as a string
                    return ip.ToString();
                }
            }

            // None was found so return nothing
            return "";
        }
    }
}
