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

// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(ClassLibrary2.Commands))]


// this attribute marks this class, as a class having ExtensionApplication methods
// Initialize and Terminate that are called on loading and unloading of this assembly 
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
            //Application.ShowAlertDialog("The commands class is Initialized");
            //if (RibbonServices.RibbonPaletteSet == null)
            //    RibbonServices.CreateRibbonPaletteSet();
                        
            PaletteSet paletteSet = new PaletteSet("Ribbon Custom")
            {
                Style = PaletteSetStyles.NameEditable |
                PaletteSetStyles.ShowPropertiesMenu |
                PaletteSetStyles.ShowAutoHideButton |
                PaletteSetStyles.ShowCloseButton |
                PaletteSetStyles.Snappable,
                Visible = true,
                Dock = DockSides.None
            };
            System.Drawing.Point StartPos = new System.Drawing.Point(0, 100);
            paletteSet.SetLocation(StartPos);
            paletteSet.SetSize(new System.Drawing.Size((int)SystemParameters.PrimaryScreenWidth - 100, 500));
            paletteSet.TitleBarLocation = PaletteSetTitleBarLocation.Left;

            
            // RibbonTab - RadTab
            // RibbonPanel - RadGroup
            // RibbonItems - RadItems
            //class1.DataContext = radRibbonView;

            
            RadRibbonView radRibbonView = new Class1().InitRibbonView();
            
            for (int i = 0; i < radRibbonView.Items.Count; i++)
            {
                Console.Write(radRibbonView.Items[i].ToString() + " ");
            }
            RibbonButton ribbonButton = new RibbonButton() { Text = "Test" };

            RibbonItem ribbonItem = (RibbonItem)ribbonButton;
            TBItem tBItem = new TBItem();
            tBItem.radButton
            RibbonObservableCollection<RibbonPanel> ribbonPns = new RibbonObservableCollection<RibbonPanel>();
            ribbonPns.Add(new RibbonPanel() { IsEnabled = true, Source = { Title = "RibbonPanel1", Id = "RibbonPanel1", Name = "RibbonPanel1", Items = { ribbonButton } } });

            RibbonPanelSource ribbonPanelSource = new RibbonPanelSource() { Id = "PanelSource1", Name = "PanelSource1", Title = "PanelSource1" };
            RibbonPanelSourceCollection ribbonPanelSources = new RibbonPanelSourceCollection() { ribbonPanelSource };
            RibbonPanel ribbonPanel = new RibbonPanel() { IsEnabled = true, Source = { } };
            RibbonPanelCollection ribbonPanels = new RibbonPanelCollection();
            RibbonTab ribbonTab = new RibbonTab() { Id = "", IsEnabled = true, Name = "Tab1", Title = "Tab1" };
            
            //paletteSet.AddVisual("Ribbon", class1);
            //RibbonControl ribbonControl = ComponentManager.Ribbon;



            //ribbonControl.Tabs.Add(new RibbonTab() { Id = })
            //editor().WriteMessage(ribbonControl.Tabs.Count.ToString());

            //PaletteSet test = new PaletteSet("Test Palette");

            //RibbonControl ribbonControl = ComponentManager.Ribbon;
            //RadRibbonView radRibbonView = class1.InitRibbonView();
            //RibbonTabCollection ribbonTabs = new RibbonTabCollection();
            //ribbonTabs.Add(new RibbonTab() { Id = "CustomRibbonTab", IsEnabled = true, Name = "CustomRibbonTab", Title = "My Custom Ribbon Tab", Panels = {  } });

            //RibbonTab ribbonTab = new RibbonTab() { Id = "RibbonTab1", IsEnabled = true, Name = "RibbonTab1", Title = "Ribbon Tab 1", Panels = { } };

            ////RibbonTab ribbonTab = new RibbonTab();

            //RibbonPanel ribbonPanel = new RibbonPanel() { IsEnabled = true, Source = radRibbonView };
            //RibbonItemCollection RibbonItems = new RibbonItemCollection();
            //RibbonItems.Add(new RibbonItem() { Id = "RibbonItem1", IsEnabled = true, IsVisible = true, Text = "RibbonItem1", ToolTip = "Ribbon Item 1"});
            ////int i = 0;
            ////foreach (var item in radRibbonView.Items)
            ////{
            ////    RibbonItems.Add(new RibbonItem() { Id = "Ribbon Item " + i, IsEnabled = true, IsVisible = true, Text = "Ribbon Item " + i, ToolTip = "Ribbon Item " + i });
            ////    // Tabs
            ////    //ribbonControl.Tabs.Add()
            ////}
            //StackPanel stackPanel3 = new StackPanel();
            //StackPanel stackPanel4 = new StackPanel();
            //stackPanel3.Children.Add(new RadRibbonButton()
            //{
            //    CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
            //    SmallImage = IconToImageSource(Properties.Resources.PV_Detail_API_579),
            //    Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            //});

            //stackPanel4.Children.Add(new RadRibbonButton()
            //{
            //    CollapseToSmall = CollapseThreshold.WhenGroupIsMedium,
            //    SmallImage = IconToImageSource(Properties.Resources.PV_Detail_Nozzle),
            //    Size = Telerik.Windows.Controls.RibbonView.ButtonSize.Large
            //});
            //RibbonPanelSourceCollection ribbonPanelSources = new RibbonPanelSourceCollection();
            //RibbonPanelSource ribbonPanelSource = new RibbonPanelSource() { Id = "Ribbon Panel 1", Name = "Ribbon Panel 1", Title = "Ribbon Panel 1", Items = { new RadRibbonGroup() { Header = "Details" , Items =
            //            {
            //                new StackPanel() { Orientation = Orientation.Vertical, Children = { stackPanel3, stackPanel4 } }
            //            }
            //        } } };

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

        private ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
