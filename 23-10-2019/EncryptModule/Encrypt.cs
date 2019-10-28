using System;
using System.Collections.Generic;

namespace EncryptModule
{
    public abstract class Encrypt
    {
        public abstract void DoEncrypt();
        public FileIO file = new FileIO();
    }

    public class MitaniEncrypt : Encrypt
    {
        public string current_path = "";
        public string EncryptKey = "";
        public string MacAddress = "";
        string HDSerial = "";
        Device device = new Device();
        public bool Expire = false;
        public string GetLicense()
        {
            string OriginKey = "";
            file.Read(ref OriginKey, ref Expire);
            return OriginKey;
        }
        public override void DoEncrypt()
        {
            GenerateKey();
            DateTime expireDate = DateTime.Now.AddDays(365);
            FileIO file = new FileIO();
            file.Write("HD Serial: " + HDSerial);
            file.Write("MAC Address: " + MacAddress);
            file.Write("Expire Date: " + expireDate.ToShortDateString());
            file.Write("Key: " + EncryptKey);
        }

        public void GenerateKey()
        {
            // Get Info
            MacAddress = device.GetMACID();
            //ArrayList temp = device.GetHDSerial();
            HDSerial = device.GetHDSerial();

            // Combine Info
            string combine = MacAddress + HDSerial;

            // Get Key
            Algorithms algorithms = new Algorithms(combine);
            EncryptKey = algorithms.EncryptKey;
        }
    }
}
