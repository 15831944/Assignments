using ClassLibrary2.ViewModel;
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
using Telerik.Windows.Controls;
using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;

using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Interop;
using System.IO;
using System.Xml;

namespace ClassLibrary2.View
{
    /// <summary>
    /// Interaction logic for Ribbon_View.xaml
    /// </summary>
    public partial class Ribbon_View : UserControl
    {
        public Ribbon_View()
        {
            StyleManager.ApplicationTheme = new MaterialTheme();
            this.DataContext = new Ribbon_ViewModel();
            InitializeComponent();
        }

    }
}
