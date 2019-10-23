using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptModule;

namespace CheckLicenseModule
{
    public abstract class LicenseFacade
    {
        public Dictionary<string, string> userInfo = new Dictionary<string, string>();
        public string Key { get; set; }
        public LicenseFacade(Dictionary<string, string> info)
        {
            userInfo = info;
        }
        public bool IsLicensed()
        {
            if (Key != "")
            {
                return true;
            }
            return false;
        }
    }

    public class MitaniLicense : LicenseFacade
    {
        public MitaniLicense(Dictionary<string, string> info) : base(info)
        {
            MitaniEncrypt encrypt = new MitaniEncrypt();
            userInfo = encrypt.GetLicense();
            foreach (var s in userInfo)
            {
                if (s.Key == "KEY")
                {
                    Key = s.Value;
                }
            }
        }

    }
}
