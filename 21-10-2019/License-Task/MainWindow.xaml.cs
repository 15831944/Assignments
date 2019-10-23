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
        public static Dictionary<string, string> UserInfo = new Dictionary<string, string>();
        MitaniLicense mitaniLicense = new MitaniLicense(UserInfo);
        MitaniGenerator mitaniGenerator = new MitaniGenerator(UserInfo);
        public MainWindow()
        {
            InitializeComponent();
            CheckLicense();
        }

        public void CheckLicense()
        {
            UserInfo = mitaniLicense.userInfo;
            if (!mitaniLicense.IsLicensed())
            {
                MessageBox.Show("Please buy a key to active this program or you can register a trial");
            }
            else
            {
                btn_Purchase.IsEnabled = false;

            }
            foreach (var item in UserInfo)
            {
                if (item.Key == "MAC_ID")
                {
                    tb_MAC.Text = item.Value;
                }
                if (item.Key == "HD_SERIAL")
                {
                    tb_HDS.Text = item.Value;
                }
                if (item.Key == "KEY")
                {
                    tb_KEY.Text = item.Value;
                }
            }
        }

        public void GenerateLicense()
        {
            UserInfo = mitaniGenerator.GenerateInfo;
            MessageBox.Show("Thanks for your purchasing!");
            btn_Purchase.IsEnabled = false;
            foreach (var item in UserInfo)
            {
                if (item.Key == "MAC_ID")
                {
                    tb_MAC.Text = item.Value;
                }
                if (item.Key == "HD_SERIAL")
                {
                    tb_HDS.Text = item.Value;
                }
                if (item.Key == "KEY")
                {
                    tb_KEY.Text = item.Value;
                }
            }
        }

        private void Btn_Purchase_Click(object sender, RoutedEventArgs e)
        {
            GenerateLicense();
        }
    }

}
