﻿using System.Collections;
using Encrypt;
namespace License_Module
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
