using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using Bricscad.Windows;
using BricscadApp;
using Teigha.Runtime;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
//[assembly: CommandClass(typeof(WpfApp1.Commands))]


//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(WpfApp1.Commands))]

namespace WpfApp1
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            MainWindow mainWindow = new MainWindow();
            PaletteSet ps = new PaletteSet("Ribbon Custom")
            {
                //ps.Add("Ribbon", ribbon_Custom);
                // set some style parameters
                Style = PaletteSetStyles.NameEditable |
                PaletteSetStyles.ShowPropertiesMenu |
                PaletteSetStyles.ShowAutoHideButton |
                PaletteSetStyles.ShowCloseButton |
                PaletteSetStyles.Snappable,

                Visible = true,
                Dock = DockSides.None
            };
            System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            ps.SetLocation(startPos);
            ps.SetSize(new System.Drawing.Size(800, 145));
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            ps.AddVisual("Ribbon", mainWindow);
        }

        public void Terminate()
        {
            
        }
    }
}
