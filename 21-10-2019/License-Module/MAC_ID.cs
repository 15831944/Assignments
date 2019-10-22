using System;
using System.Net.NetworkInformation;

namespace License_Module
{
    public class MAC_ID
    {
        const int MIN_MAC_ADDR_LENGTH = 12;
        public string MacAddress { get; set; }
        long maxSpeed = -1;

        public MAC_ID()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && !string.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    maxSpeed = nic.Speed;
                    MacAddress = tempMac;
                }
            }
        }

        public string GetMacAddress()
        {
            return MacAddress;
        }
    }
}
