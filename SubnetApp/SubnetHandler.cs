using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SubnetApp
{
    //class responsible for subnetting logic
    internal class SubnetHandler
    {
        public bool isInRange(IPAddress netIP, IPAddress subnetIP, int maskLength)
        {
            //convert IP into 32 bit sequence(binary represantation)
            int networkBytes = BitConverter.ToInt32(netIP.GetAddressBytes(), 0);
            // convert IP into 32 bit sequence (binary represantation)
            int subnetworkIP = BitConverter.ToInt32(subnetIP.GetAddressBytes(), 0);
            // calculating a binary reoresantation of a network mask by shifting -1 left by the number of uncoverd mask length
            int maskIP = IPAddress.HostToNetworkOrder(-1 << (32 - maskLength));

            //logical AND operation between first network address and mask, compared to ip and mask, to check if they are from the same subnet
            bool ipIsInRange = (networkBytes & maskIP) == (subnetworkIP & maskIP);

            return ipIsInRange;
        }
    }
}
