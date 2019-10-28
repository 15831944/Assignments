using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

using Teigha.Runtime;
using Bricscad.Windows;

// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(ClassLibrary1.Commands))]


// this attribute marks this class, as a class having ExtensionApplication methods
// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(ClassLibrary1.Commands))]

namespace ClassLibrary1
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            var app = Application.AcadApplication as AcadApplication;
            if (app == null)
            {
                throw new NullReferenceException("Could Not Get Application");
            }
            Class1 window = new Class1();
            window.Height = 500;
            window.Width = 600;
            StyleManager.ApplicationTheme = new VisualStudio2019Theme();
            window.Show();
            //RadRibbonView radRibbonView = InitRibbonView();
            //RibbonTab ribbonTab = (RibbonTab)radRibbonView;
            //RibbonPaletteSet ribbonPaletteSet = RibbonServices.CreateRibbonPaletteSet();
            //ribbonPaletteSet.RibbonControl.Tabs.Add((RibbonTab)radRibbonView);

            //RibbonTab ribbonTab = new RibbonTab();
            //RibbonTabCollection ribbonTabs = new RibbonTabCollection();
            //ribbonTabs.Add()
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

        public RadRibbonView InitRibbonView()
        {
            RadRibbonView ribbonView = new RadRibbonView();
            //ribbonView.Items.Add(new RadRibbonTab() { Header = "Home" });
            //ribbonView.Items.Add(new RadRibbonGroup() { Header = "Home", Items = { new RadRibbonButton() { Text = "Paste" }, new RadRibbonButton() { Text = "Format" }
            //, new RadRibbonButton() { Text = "Paste" }, new RadRibbonButton() { Text = "Format" } } });
            ribbonView.Items.Add(new RadRibbonTab()
            {
                Header = "Home",
                Items =
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
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Tools" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "View" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "3D" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Diagonostics" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "ESL" });
            ribbonView.Items.Add(new RadRibbonTab() { Header = "Help" });
            return ribbonView;
        }
    }
}
