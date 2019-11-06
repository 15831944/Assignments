using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BricscadWPF.Views;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(BricscadWPF.Commands))]

//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(BricscadWPF.Commands))]

namespace BricscadWPF
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            PaletteSet paletteSet = new PaletteSet("Test")
            {
                Style = PaletteSetStyles.NameEditable |
                PaletteSetStyles.ShowPropertiesMenu |
                PaletteSetStyles.ShowAutoHideButton |
                PaletteSetStyles.ShowCloseButton |
                PaletteSetStyles.Snappable,

                Visible = true,
                Dock = DockSides.None
            };
            System.Drawing.Point startPos = new System.Drawing.Point(0, 50);
            paletteSet.SetLocation(startPos);
            paletteSet.SetSize(new System.Drawing.Size(900, 900));
            paletteSet.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            UIViews uIViews = new UIViews();
            paletteSet.AddVisual("Ribbon", uIViews);
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
