using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        RadWindow window = new RadWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.window.Close();
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            window.Width = 370;
            window.Height = 290;

            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner; // Position of UI
            window.Header = "Demo"; // Title
            window.CanClose = false;
            window.Show();
        }
    }
}
