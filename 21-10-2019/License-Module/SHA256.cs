using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public class SHA256Encrypt
    {
        public string Key { get; set; }
        public string GetEncrypt()
        {
            return Key;
        }
        public SHA256Encrypt(string GenerateString)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Key));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Key = builder.ToString();
            }
        }
        // Generate a random string with a given size  
        
    }
}
