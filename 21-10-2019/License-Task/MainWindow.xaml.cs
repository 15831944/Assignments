using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using License_Module;
using CheckLicense;
using GenerateLicense;

namespace License_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test test = new Test();
        }
    }

    public class Test
    {
        public Test()
        {
            MitaniGenerator mitaniGenerator = new MitaniGenerator();
            //MacAddress = mAC_ID.GetMacAddress();
            //HDList = HD_Serial.hardDriveDetails;
        }

        public void Print()
        {
            //MessageBox.Show("Your MAC Address: " + MacAddress);

            //foreach(License_Module.HardDrive item in HD_Serial.hardDriveDetails)
            //{
            //    MessageBox.Show("HD Serial: " + item.SerialNo);
            //}
        }

    }

}
