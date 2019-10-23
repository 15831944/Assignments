using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class Component
    {
        public static string MAC_Address { get; set; }
        public static ArrayList HardDriveList;
        public static string HDSerial { get; set; }

        public Component()
        {

        }

        public static void GetComponent()
        {
            MAC_ID mAC_ID = new MAC_ID();
            HardDiskSerial HD_Serial = new HardDiskSerial();
            HardDriveList = HD_Serial.hardDriveDetails; // test
        }
    }
}
