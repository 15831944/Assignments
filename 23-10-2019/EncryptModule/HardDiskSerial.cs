using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class HardDiskSerial : Component
    {
        public ArrayList hardDriveDetails = new ArrayList();
        public HardDiskSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); //Serial Number
                hardDriveDetails.Add(hd);
                if (i == 0)
                {
                    HDSerial = wmi_HD["SerialNumber"].ToString().Trim();
                }
            }
        }
    }
}
