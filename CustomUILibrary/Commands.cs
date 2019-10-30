using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;

[assembly: CommandClass(typeof(CustomUILibrary.Commands))]

[assembly: ExtensionApplication(typeof(CustomUILibrary.Commands))]

namespace CustomUILibrary
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
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
            paletteSet.SetSize(new System.Drawing.Size((int)SystemParameters.PrimaryScreenWidth - 100, 400));
            paletteSet.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            

            Class1 class1 = new Class1((int)SystemParameters.PrimaryScreenWidth - 100, 400);
            paletteSet.AddVisual("Ribbon", class1);
            PaletteSet test = new PaletteSet("Test Palette");
        }

        public void Terminate()
        {
            
        }
    }
}
