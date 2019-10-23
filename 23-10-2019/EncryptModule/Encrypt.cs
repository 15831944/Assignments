using System.Collections.Generic;

namespace EncryptModule
{
    public abstract class Encrypt
    {
        public abstract void DoEncrypt(ref Dictionary<string, string> GenerateInfo);
    }

    public class MitaniEncrypt : Encrypt
    {
        FileIO file = new FileIO();
        public Dictionary<string, string> GetLicense()
        {
            Dictionary<string, string> UserInfo = new Dictionary<string, string>();
            file.Read(ref UserInfo);
            return UserInfo;
        }
        public override void DoEncrypt(ref Dictionary<string, string> GenerateInfo)
        {
            Algorithms algorithms = new Algorithms();
            string EncryptKey = algorithms.EncryptKey;
            GenerateInfo["KEY"] = EncryptKey;

            Device device = new Device();
            string MacAddress = device.GetMACID();
            //ArrayList temp = device.GetHDSerial();
            string HDSerial = device.GetHDSerial();

            FileIO file = new FileIO();
            file.Write("Key: " + EncryptKey);
        }
    }
}
