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
            // init new Palette
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

            System.Drawing.Point StartPos = new System.Drawing.Point(100, 100);
            paletteSet.SetLocation(StartPos);
            paletteSet.SetSize(new System.Drawing.Size(900, 500));
            paletteSet.TitleBarLocation = PaletteSetTitleBarLocation.Left;

            Class1 class1 = new Class1();
            //RadRibbonView radRibbonView = new RadRibbonView();
            //class1.DataContext = class1.InitRibbonView();
            paletteSet.AddVisual("Ribbon", class1.radWindow);

            PaletteSet test = new PaletteSet("Test Palette");
            RibbonControl ribbonControl = ComponentManager.Ribbon;
            //ribbonControl.Tabs.Add(class1.radWindow)
            //RibbonTab ribbonTab = new RibbonTab() { Name = "Custom Ribbon", IsEnabled = true, Title = "My Custom Ribbon" };
            //ribbonControl.Tabs.Add(ribbonTab);
            //ribbonTab.Clone();
            /*
             ViewModel.RibbonTab_ViewModel ribbonTab_ViewModel = new ViewModel.RibbonTab_ViewModel();
            ribbonTab_ViewModel.ReadXML();
            ribbonTab_ViewModel.ConverToTelerik(); 
             */

            /* Temp */
            //RibbonControl ribbonControl2 = ComponentManager.Ribbon;
            //foreach (var item in ribbonControl2.Tabs)
            //{
            //    ribbonControl.Tabs.Remove(item);
            //}
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


    }
}
