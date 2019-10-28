using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class Algorithms
    {
        public string EncryptKey { get; set; }

        public Algorithms(string CombineInfo)
        {
            SHA256Encrypt encrypt = new SHA256Encrypt(CombineInfo);
            EncryptKey = encrypt.Key;
        }
    }
}
