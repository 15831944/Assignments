using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class MAC_ID : Component
    {
        const int MIN_MAC_ADDR_LENGTH = 12;
        long maxSpeed = -1;

        public MAC_ID()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && !string.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    maxSpeed = nic.Speed;
                    MAC_Address = tempMac;
                }
            }
        }

        public string GetMacAddress()
        {
            return MAC_Address;
        }
    }
}
