using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encrypt;

namespace GenerateLicense
{
    public abstract class LicenseGenerator
    {
        public Dictionary<string, string> GenerateInfo = new Dictionary<string, string>();
        public LicenseGenerator(Dictionary<string, string> info)
        {
            GenerateInfo = info;
        }
    }

    public class MitaniGenerator : LicenseGenerator
    {
        public MitaniGenerator(Dictionary<string, string> info) : base (info)
        {
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
            mitaniEncrypt.DoEncrypt(ref GenerateInfo);
            //GenerateKey = GenerateInfo["KEY"];
            //MessageBox.Show("You generate key: " + GenerateKey);
        }
    }
}
