using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encrypt;

namespace CheckLicense
{
    public abstract class LicenseFacade
    {
        public string key { get; set; }
        public bool IsLicensed()
        {
            if (key != "")
            {
                return true;
            }
            return false;
        }
    }

    public class MitaniLicense : LicenseFacade
    {
        Encrypt.Encrypt encrypt = new MitaniEncrypt();
        public MitaniLicense()
        {
            key = encrypt.EncryptKey;
        }
    }

}