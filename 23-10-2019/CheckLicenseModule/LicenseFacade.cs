using EncryptModule;

namespace CheckLicenseModule
{
    public abstract class LicenseFacade
    {
        public string TextKey { get; set; }
        public string OriginKey { get; set; }
        public string Path { get; set; }
        public bool Expire { get; set; }
        public LicenseFacade()
        {

        }
        public bool IsLicensed()
        {
            if (TextKey.Equals(OriginKey) && !Expire)
            {
                return true;
            }
            return false;
        }
    }
    public class MitaniLicense : LicenseFacade
    {
        public MitaniLicense()
        {
            MitaniEncrypt encrypt = new MitaniEncrypt();
            TextKey = encrypt.GetLicense().Trim(); // Get Key from Text file
            Expire = encrypt.Expire; // expire
            encrypt.GenerateKey();
            OriginKey = encrypt.EncryptKey;
            //Path = encrypt.current_path; 
        }
    }
}
