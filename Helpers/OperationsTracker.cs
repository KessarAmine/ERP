using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace DevKbfSteel.Helpers
{
    public static class OperationsTracker
    {
        public static string GetIP(string ipAddress)
        {
            // grab all online interfaces
            var query = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n =>
                    n.OperationalStatus == OperationalStatus.Up && // only grabbing what's online
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(_ => new
                {
                    PhysicalAddress = _.GetPhysicalAddress(),
                    IPProperties = _.GetIPProperties(),
                });
            var ipAddresse = query.FirstOrDefault().IPProperties.UnicastAddresses[1].Address.ToString();
            return ipAddresse;
        }
        public static string GetIP2()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
        public static string GetMacByIP(string ipAddress)
        {
            // grab all online interfaces
            var query = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n =>
                    n.OperationalStatus == OperationalStatus.Up && // only grabbing what's online
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback 
                    )
                .Select(_ => new
                {
                    PhysicalAddress = _.GetPhysicalAddress(),
                    IPProperties = _.GetIPProperties(),
                });
            var Mac = query.FirstOrDefault().PhysicalAddress.ToString();
            return Mac;
        }
    }
}