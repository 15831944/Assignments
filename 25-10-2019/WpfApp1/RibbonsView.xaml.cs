using System;
using System.Linq;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RibbonsView.xaml
    /// </summary>
    public partial class RibbonsView : RadWindow
    {
        RadWindow window;
        public RibbonsView()
        {
            InitializeComponent();
            InitRibbonView();
            //var window = RadWindowManager.Current.GetWindows().Where(a => a.IsActiveWindow).FirstOrDefault();
            
        }

        public RadRibbonView InitRibbonView()
        {
            RadRibbonView ribbonView = new RadRibbonView();
            //ribbonView.Items.Add(new RadRibbonTab() { Header = "Home" });
            //ribbonView.Items.Add(new RadRibbonGroup() { Header = "Home", Items = { new RadRibbonButton() { Text = "Paste" }, new RadRibbonButton() { Text = "Format" }
            //, new RadRibbonButton() { Text = "Paste" }, new RadRibbonButton() { Text = "Format" } } });
            ribbonView.Items.Add( new RadRibbonTab() { Header = "Home", Items =
                {
                    new RadRibbonGroup() { Header = "File", Items =
                    {
                        new RadRibbonSplitButton { Text = "New", VerticalAlignment = System.Windows.VerticalAlignment.Top, SmallImage = new BitmapImage(new Uri("/res/02_01-FileNew.ico", UriKind.Relative)) },
                        new RadRibbonButton { SplitText = true, Text = "Open...", Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large, SmallImage = new BitmapImage(new Uri("/res/02_02-File Open.ico", UriKind.Relative)) },
                        new RadRibbonSplitButton { VerticalAlignment = System.Windows.VerticalAlignment.Top, Text = "Save", Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Medium,
                            SmallImage = new BitmapImage(new Uri("/res/02_03-File Save.ico", UriKind.Relative)) },
                    }},
                    new RadRibbonGroup() { Header = "Elements" , Items =
                    {
                        new RadRibbonButton { VerticalAlignment = System.Windows.VerticalAlignment.Top, Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large,
                            SmallImage = new BitmapImage(new Uri("/res/PV_Element_Cylinder.ico", UriKind.Relative)) },
                        new RadRibbonButton { VerticalAlignment = System.Windows.VerticalAlignment.Top, Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large,
                            SmallImage = new BitmapImage(new Uri("/res/PV_Element_Cylinder.ico", UriKind.Relative)) },
                    }}
                }
            });
            ribbonView.Items.Add( new RadRibbonTab() { Header = "Tools" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "View" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "3D" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Diagonostics" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "ESL" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Help" });
            return ribbonView;
        }

        private void RadWindow_Activated(object sender, System.EventArgs e)
        {
            window = (RadWindow)sender;
            var ribbonView = InitRibbonView();
            window.Content = ribbonView;
        }
    }
}
