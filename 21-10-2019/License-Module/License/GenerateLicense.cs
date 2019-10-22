using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encrypt;

namespace GenerateLicense
{
    public class LicenseGenerator
    {
        public string GenerateKey { get; set; }
        public LicenseGenerator()
        {
            
        }
    }

    public class MitaniGenerator : LicenseGenerator
    {
        public MitaniGenerator()
        {
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
            mitaniEncrypt.DoEncrypt();
            GenerateKey = mitaniEncrypt.EncryptKey;
            MessageBox.Show("You generate key: " + GenerateKey);
        }
    }
}
