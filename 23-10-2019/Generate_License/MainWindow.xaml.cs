using EncryptModule;
using System;
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
using EncryptModule;
using CheckLicenseModule;

namespace Generate_License
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<string, string> UserInfo = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            if (!IsLicensed())
            {
                btn_Purchase.IsEnabled = false;
            }
        }

        private void Btn_Purchase_Click(object sender, RoutedEventArgs e)
        {
            MitaniGenerator mitaniGenerator = new MitaniGenerator(UserInfo);
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
            mitaniEncrypt.DoEncrypt(ref UserInfo);
        }

        public bool IsLicensed()
        {
            MitaniLicense mitaniLicense = new MitaniLicense(UserInfo);
            if (mitaniLicense.IsLicensed())
            {
                return true;
            }
            return false;
        }
    }

    public class LicenseGenerator : MainWindow
    {
        public LicenseGenerator(Dictionary<string, string> info)
        {
            UserInfo = info;
        }
    }
    public class MitaniGenerator : LicenseGenerator
    {
        public MitaniGenerator(Dictionary<string, string> info) : base(info)
        {
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
            mitaniEncrypt.DoEncrypt(ref UserInfo);
            //GenerateKey = GenerateInfo["KEY"];
            //MessageBox.Show("You generate key: " + GenerateKey);
        }
    }
}
