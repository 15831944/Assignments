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
        public List<InputUI> UIInputList;
        public double height;
        public double width;
        public List<InputUI> GetInputUI()
        {
            List<InputUI> inputs = new List<InputUI>();
            inputs.Add(new InputUI() { text = "New Model" });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "License Days Left" });
            inputs.Add(new InputUI() { text = "..." });
            UIInputList = inputs;
            return UIInputList;
        }


        public UserControl2()
        {
            InitializeComponent();
            LoadUI();
            this.UpdateLayout();
        }

        public void LoadUI()
        {
            parent.Height = 26;
            GetInputUI();
            //DockPanel.VerticalAlignment = VerticalAlignment.Stretch;
            DockPanel.HorizontalAlignment = HorizontalAlignment.Left;
            DockPanel.Children.Add(new Label() { Content = UIInputList[0].text, HorizontalAlignment = HorizontalAlignment.Left, Foreground = new SolidColorBrush(Colors.White), FontSize = 9 });
            WrapPanel wrapPanel = new WrapPanel() { Name = "WrapPanel", HorizontalAlignment = HorizontalAlignment.Right, Height = 26 };
            DockPanel.Children.Add(wrapPanel);
            foreach (var item in UIInputList)
            {
                wrapPanel.Children.Add(new Label() { Content = item.text, Foreground = new SolidColorBrush(Colors.White), FontSize = 9 });
            }
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
                MinimumSize = new System.Drawing.Size((int)this.ActualWidth, (int)this.ActualHeight),
                Size = new System.Drawing.Size((int)this.ActualWidth, (int)this.ActualHeight),
            };
            //System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            //ps.SetLocation(startPos);
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            ps.AddVisual("Ribbon", this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            height = this.ActualHeight;
            width = this.ActualWidth;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            width = e.NewSize.Width;
            height = e.NewSize.Height;
        }
    }
}
