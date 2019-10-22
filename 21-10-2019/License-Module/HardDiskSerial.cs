﻿using System;
using System.Management;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Module
{
    public class HardDiskSerial
    {
        public string HDSerial { get; set; }
        public ArrayList hardDriveDetails = new ArrayList();
        public HardDiskSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); //Serial Number
                hardDriveDetails.Add(hd);
            }
        }
    }
}