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

namespace RibbonClass.Views
{
    /// <summary>
    /// Interaction logic for Ribbon_Custom.xaml
    /// </summary>
    public partial class Ribbon_Custom : UserControl
    {
        public Ribbon_Custom()
        {
            InitializeComponent();
        }

        private void RibbonTabViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            //ViewModel.RibbonTab_ViewModel ribbonTab = new ViewModel.RibbonTab_ViewModel();
            //ribbonTab.ReadXML();
            //RibbonTabViewControl.DataContext = ribbonTab;
        }
    }
}
