using Bricscad.Windows;
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

namespace RibbonBricscad
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        public void InitUI()
        {
            PaletteSet ps = new PaletteSet("Bottom Toolbar")
            {
                Style = PaletteSetStyles.NameEditable |
                PaletteSetStyles.ShowPropertiesMenu |
                PaletteSetStyles.ShowAutoHideButton |
                PaletteSetStyles.ShowCloseButton |
                PaletteSetStyles.Snappable,
                Visible = true,
                Dock = DockSides.Bottom,
                KeepFocus = true,
                MinimumSize = new System.Drawing.Size(577, 30),
                Size = new System.Drawing.Size(577, 30),
            };
            System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            ps.SetLocation(startPos);
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            ps.AddVisual("Ribbon", this);

            //Bricscad.Windows.StatusBar
        }
    }
}
