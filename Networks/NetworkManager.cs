using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Console_Toolkit.Networks
{
    internal class NetworkManager
    {
        public static bool IPOnline(string ip)
        {
            try
            {
                Ping ping;
                PingReply pingReply;

                ping = new Ping();
                pingReply = ping.Send(ip);
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
