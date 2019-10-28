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
            //Application.ShowAlertDialog("The commands class is Initialized");
            if (RibbonServices.RibbonPaletteSet == null)
                RibbonServices.CreateRibbonPaletteSet();
            Class1 class1 = new Class1();            
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
            RadRibbonView radRibbonView = new RadRibbonView();
            //class1.DataContext = radRibbonView;
            paletteSet.AddVisual("Ribbon", class1.radWindow);
            PaletteSet test = new PaletteSet("Test Palette");
            RibbonControl ribbonControl = ComponentManager.Ribbon;
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
