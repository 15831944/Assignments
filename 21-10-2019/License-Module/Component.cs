using System.Collections;
using Encrypt;
namespace License_Module
{
    public class Component
    {
        public static string MAC_Address { get; set; }
        public static ArrayList HardDriveList;
        
        public Component()
        {
            MAC_ID mAC_ID = new MAC_ID();
            HardDiskSerial HD_Serial = new HardDiskSerial();
            MAC_Address = mAC_ID.MacAddress;
            HardDriveList = HD_Serial.hardDriveDetails;
        }
    }
}
