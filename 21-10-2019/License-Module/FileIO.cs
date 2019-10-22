using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public class FileIO
    {
        static string path = @"D:\Assignments\21-10-2019\License-Module\bin\Debug\MyTest.txt";
        public void Write(string StringToWrite)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(StringToWrite);
                }
            }
            else
            {
                File.AppendAllText(path, StringToWrite + Environment.NewLine);
            }
        }

        public string Read()
        {
            string temp = "";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("Key:"))
                        {
                            temp = s;
                            break;
                        }
                    }
                    
                }
            }
            return temp;
        }
    }
}
