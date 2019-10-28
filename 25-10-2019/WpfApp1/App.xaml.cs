using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            RibbonsView window = new RibbonsView();
            window.Height = 500;
            window.Width = 600;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            StyleManager.ApplicationTheme = new VisualStudio2019Theme();
            window.Show();
        }
    }
}
