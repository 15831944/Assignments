using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class FileIO
    {
        public static string path = @AppDomain.CurrentDomain.BaseDirectory + "MyTest.txt";
        public void Write(string StringToWrite)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(StringToWrite);
                }
                File.SetAttributes(path, FileAttributes.Hidden);
            }
            else
            {
                File.SetAttributes(path, FileAttributes.Normal);
                bool Write = false;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("Key:"))
                        {
                            Write = true;
                        }
                    }
                }
                if (Write)
                {
                    string str = File.ReadAllText(path);
                    str = str.Replace("Key:", StringToWrite + Environment.NewLine);
                    File.WriteAllText(path, str);
                }
                else
                {
                    File.AppendAllText(path, StringToWrite + Environment.NewLine);
                }
                File.SetAttributes(path, FileAttributes.Hidden);
            }
        }

        public void Read(ref Dictionary<string, string> UserInfo)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("Mac Address:"))
                        {
                            if (s.Length > 13)
                            {
                                UserInfo.Add("MAC_ID", s.Substring(13));
                            }
                            else
                            {
                                UserInfo.Add("MAC_ID", "");
                            }
                        }
                        if (s.Contains("HD Serial:"))
                        {
                            if (s.Length > 11)
                            {
                                UserInfo.Add("HD_SERIAL", s.Substring(11));
                            }
                            else
                            {
                                UserInfo.Add("HD_SERIAL", "");
                            }
                        }
                        if (s.Contains("Key:"))
                        {
                            if (s.Length > 4)
                            {
                                UserInfo.Add("KEY", s.Substring(4));
                            }
                            else
                            {
                                UserInfo.Add("KEY", "");
                            }
                        }
                    }
                }
            }
            else
            {
                Device device = new Device();
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Mac Address: " + device.GetMACID());
                    sw.WriteLine("HD Serial: " + device.GetHDSerial());
                    sw.WriteLine("Key: ");
                }
                File.SetAttributes(path, FileAttributes.Hidden);
                UserInfo.Add("MAC_ID", device.GetMACID());
                UserInfo.Add("HD_SERIAL", device.GetHDSerial());
                UserInfo.Add("KEY", "");
            }
        }
    }
}
