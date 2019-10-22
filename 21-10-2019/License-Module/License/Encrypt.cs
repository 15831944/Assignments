using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using License_Module;
namespace Encrypt
{
    public abstract class Encrypt
    {
        public string EncryptKey { get; set; }
        public abstract void DoEncrypt();
        public Encrypt()
        {
            FileIO file = new FileIO();
            if (file.Read())
        }
    }

    public class MitaniEncrypt : Encrypt
    {
        public override void DoEncrypt()
        {
            Algorithms algorithms = new Algorithms();
            EncryptKey = algorithms.EncryptKey;

            Device device = new Device();
            string MacAddress = device.GetMACID();
            //ArrayList temp = device.GetHDSerial();
            string HDSerial = device.GetHDSerial();

            FileIO file = new FileIO();
            file.Write("Mac Address: " + MacAddress);
            file.Write("HD Serial: " + HDSerial);
            file.Write("Key: " + EncryptKey);
        }
    }
}
