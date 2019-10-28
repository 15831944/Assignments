using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EncryptModule
{
    public class FileIO
    {
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LicenseKey.txt";
        //public static string path = @AppDomain.CurrentDomain.BaseDirectory + "MyTest.txt";
        public void Write(string StringToWrite)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(StringToWrite);
                }
                FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.AllAccess, path);
                f.Demand();
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
        public void Read(ref string keyval, ref bool expire)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("Key:"))
                        {
                            if (s.Length > 4)
                            {
                                keyval = s.Substring(4);
                            }
                            else
                            {
                                keyval = "";
                            }
                        }
                        if (s.Contains("Expire Date:"))
                        {
                            if (s.Length > 12)
                            {
                                
                                if (DateTime.Parse(s.Substring(12)) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                                {
                                    expire = false;
                                }
                                else
                                {
                                    expire = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                keyval = "";
            }
        }
        public string GetPath()
        {
            return path;
        }
    }
}
