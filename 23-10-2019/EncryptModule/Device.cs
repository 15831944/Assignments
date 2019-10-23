using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class Device
    {
        public Device()
        {
            Component.GetComponent();
        }
        public string GetMACID()
        {
            return Component.MAC_Address;
        }

        public string GetHDSerial()
        {
            return Component.HDSerial;
        }
    }
}
