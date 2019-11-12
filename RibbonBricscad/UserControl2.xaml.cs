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
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "License Days Left:" });
            inputs.Add(new InputUI() { text = "..." });
            UIInputList = inputs;
            return UIInputList;
        }


        public UserControl2()
        {
            InitializeComponent();
            InitUI();
        }

        public void LoadUI()
        {
            GetInputUI();
            
            RowDefinition rowDef = new RowDefinition();
            parent.RowDefinitions.Add(rowDef);
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            parent.ColumnDefinitions.Add(colDef1);
            parent.ColumnDefinitions.Add(colDef2);
            Label label = new Label() { Content = "Press F1 for Help", Foreground = new SolidColorBrush(Colors.White), FontSize = 12, Name = "HelpLb", VerticalAlignment = VerticalAlignment.Center };
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 0);
            parent.Children.Add(label);
            int i = 0;
            StackPanel stackPanel = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Right, Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            Label lb = new Label();
            foreach (var item in UIInputList)
            {
                lb = new Label()
                {
                    Content = item.text,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontSize = 12,
                    Name = "Lb" + i
                };
                stackPanel.Children.Add(lb);
                i++;
            }
            Grid.SetRow(stackPanel, 0);
            Grid.SetColumn(stackPanel, 1);
            parent.Children.Add(stackPanel);
        }

        public void InitUI()
        {
            LoadUI();
            PaletteSet ps = new PaletteSet("Bottom Toolbar", new Guid("87374E16-C0DB-4F3F-9271-7A71ED921566"))
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
            var PSSize = new System.Drawing.Size(1024, 40);
            ps.Size = new System.Drawing.Size(PSSize.Width, PSSize.Height);
            ps.Size = PSSize;
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
