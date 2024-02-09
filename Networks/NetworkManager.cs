using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using Console_Toolkit.ProgramTools;
using IPinfo;
using IPinfo.Models;

namespace Console_Toolkit.Networks
{
    internal class NetworkManager
    {
        public static IPinfoClient client;

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

        // Gets a list of the local ipv4 address online, looks like 192.43.164.6 (not my address suckers)
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

        // Return an array of the information gather from an ip address, using IPInfo
        public static Dictionary<string, string> IPInformation(string ip)
        {
            // Get the response containing the information
            IPResponse ipResponse = client.IPApi.GetDetails(ip);

            // Create the dictionary
            Dictionary<string, string> info = new Dictionary<string, string>
            {
                // Add the value to the dictionary
                { "City", ipResponse.City },
                { "Region", ipResponse.Region },
                { "Country", ipResponse.CountryName },
                { "Location", ipResponse.Loc },
                { "Timezone", ipResponse.Timezone },
                { "Host Name", ipResponse.Hostname }
            };

            return info;
        }
    }
}
