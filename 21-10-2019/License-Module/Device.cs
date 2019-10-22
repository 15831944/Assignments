using System.Collections;

namespace License_Module
{
    public class Device : Component
    {
        public string GetMACID()
        {
            return MAC_Address;
        }

        public string GetHDSerial()
        {
            return HDSerial;
        }
    }
}
