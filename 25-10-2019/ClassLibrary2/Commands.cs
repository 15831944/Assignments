using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Reflection;
using System.Linq;
using ClassLibrary2.View;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
//[assembly: CommandClass(typeof(ClassLibrary2.Commands))]


//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(ClassLibrary2.Commands))]

namespace ClassLibrary2
{
    public class Commands : IExtensionApplication
    {
        public Commands()
        {

        }

        public void Initialize()
        {
            StyleManager.ApplicationTheme = new MaterialTheme();
            Ribbon_View ribbon_View = new Ribbon_View();
            //Application.ShowAlertDialog("The commands class is Initialized");
            //if (RibbonServices.RibbonPaletteSet == null)
            //    RibbonServices.CreateRibbonPaletteSet();

            //Class1 class1 = new Class1();
            //PaletteSet paletteSet = new PaletteSet("Ribbon Custom")
            //{
            //    Style = PaletteSetStyles.NameEditable |
            //    PaletteSetStyles.ShowPropertiesMenu |
            //    PaletteSetStyles.ShowAutoHideButton |
            //    PaletteSetStyles.ShowCloseButton |
            //    PaletteSetStyles.Snappable,
            //    Visible = true,
            //    Dock = DockSides.None
            //};
            //System.Drawing.Point StartPos = new System.Drawing.Point(0, 100);
            //paletteSet.SetLocation(StartPos);
            ////paletteSet.SetSize(new System.Drawing.Size((int)SystemParameters.PrimaryScreenWidth - 100, 500));
            //paletteSet.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            //paletteSet.AddVisual("Ribbon", class1.InitRibbonView());


            //addWPFControls();
            //class1.InitRbControl();
            //class1.radRibbonView
        }

        public static void addWPFControls()
        {
            RibbonControl rbnCtrl = ComponentManager.Ribbon;

            if (rbnCtrl == null)
                return;
            RibbonPanelSource srcPanel = new RibbonPanelSource();
            srcPanel.Title = "Panel hosting WPF Controls";
            srcPanel.Id = "PanelWithWPF";
            RibbonPanel panel = new RibbonPanel();
            panel.Source = srcPanel;
            RibbonTab tab = new RibbonTab();
            tab.Title = "Tab with WPF Controls";
            tab.Id = "TabWPF";
            tab.Panels.Add(panel);
            rbnCtrl.Tabs.Add(tab);

            System.Windows.Controls.StackPanel wrapPanel = new System.Windows.Controls.StackPanel();
            Class1 class1 = new Class1();

            wrapPanel.Children.Add(class1.InitRibbonView((int)SystemParameters.PrimaryScreenWidth, 360));
            wrapPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;

            panel.SetWPFControl(wrapPanel, "test");
            var productName = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute)).OfType<AssemblyProductAttribute>().FirstOrDefault().Product;
        }

        static void addContent(RibbonTab rtab)
        {
            rtab.Panels.Add(AddOnePanel());
        }

        static RibbonPanel AddOnePanel()
        {
            RibbonButton rb;
            RibbonPanelSource rps = new RibbonPanelSource();
            rps.Title = "Test One";
            RibbonPanel rp = new RibbonPanel();
            rp.Source = rps;

            rb = new RibbonButton();
            rb.Id = "Test Button";
            //rb.ShowText = true;
            rb.Text = "Test Button";
            //Add the Button to the Tab
            rps.Items.Add(rb);
            return rp;
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }

        public static Editor editor()
        {
            Document document = Bricscad.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }

        private static ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
