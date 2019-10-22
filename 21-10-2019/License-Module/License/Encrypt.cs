using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public abstract class Encrypt
    {
        public string EncryptKey { get; set; }
        public abstract void DoEncrypt();
        public Encrypt()
        {
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
        }
    }

    public class MitaniEncrypt : Encrypt
    {
        public override void DoEncrypt()
        {
            FileIO file = new FileIO();
            if (file.Read() != "")
            {
                EncryptKey = file.Read();
            }
            else
            {
                EncryptKey = "";
            }
            //Algorithms algorithms = new Algorithms();
            //EncryptKey = algorithms.EncryptKey;
            //file.Write(EncryptKey);
        }
    }
}
