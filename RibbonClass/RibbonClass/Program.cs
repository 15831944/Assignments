using RibbonClass.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RibbonClass
{
    class Program
    {
        [STAThread]
        public static int Main()
        {
            //UI_Telerik user = new UI_Telerik();
            //user.Show();
            Window window = new Window
            {
                Width = 700,
                Height = 200
            };
            StackPanel stack = new StackPanel() { Orientation = Orientation.Vertical };
            stack.Children.Add(new Ribbon_View());
            window.Content = stack;
            window.Show();
            return 1;
        }
    }
}
