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

namespace Generate_License
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Btn_Purchase_Click(object sender, RoutedEventArgs e)
        {
            MitaniGenerator mitaniGenerator = new MitaniGenerator();
            if (mitaniGenerator.EncryptKey != "")
            {
                MessageBox.Show("Thanks for your purchasing!");
                btn_Purchase.IsEnabled = false;
                tb_KEY.Text = mitaniGenerator.EncryptKey;
            }
        }
    }
    public class LicenseGenerator : MainWindow
    {
        public LicenseGenerator()
        {

        }
    }
    public class MitaniGenerator : LicenseGenerator
    {
        public string EncryptKey;
        public MitaniGenerator()
        {
            MitaniEncrypt mitaniEncrypt = new MitaniEncrypt();
            mitaniEncrypt.DoEncrypt();
            EncryptKey = mitaniEncrypt.EncryptKey;
        }
    }
}
