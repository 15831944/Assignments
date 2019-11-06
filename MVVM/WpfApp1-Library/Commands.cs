using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using Bricscad.Windows;
using BricscadApp;
using System.Drawing;
using System.Windows.Forms.Integration;
using Teigha.Runtime;
using WpfApp1.ViewModels;
using WpfApp1.Views;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(WpfApp1.Commands))]


//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(WpfApp1.Commands))]

namespace WpfApp1
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            PaletteSet ps = null;
            if (ps == null)
            {
                //Create the palette set
                ps = new PaletteSet("WPF Palette");
                ps.Size = new Size(900, 900);
                ps.DockEnabled = (DockSides)((int)DockSides.Left + (int)DockSides.Right);

                // Create user control instance and host it on a palette using AddVisual()
                BricscadUI uc = new BricscadUI();
                ps.AddVisual("AddVisual", uc);

                //MainWindow uc2 = new MainWindow();
                //ElementHost host = new ElementHost();
                //host.AutoSize = true;
                //host.Dock = System.Windows.Forms.DockStyle.Fill;
                //host.Child = uc2;
                //ps.Add("Add ElementHost", host);
            }

            // Display Palette Set
            ps.KeepFocus = true;
            ps.Visible = true;
            

            //MainWindow mainWindow = new MainWindow();
            //PaletteSet ps = new PaletteSet("Ribbon Custom")
            //{
            //    //ps.Add("Ribbon", ribbon_Custom);
            //    // set some style parameters
            //    Style = PaletteSetStyles.NameEditable |
            //    PaletteSetStyles.ShowPropertiesMenu |
            //    PaletteSetStyles.ShowAutoHideButton |
            //    PaletteSetStyles.ShowCloseButton |
            //    PaletteSetStyles.Snappable,
            //    Visible = true,
            //    Dock = DockSides.None
            //};
            //System.Drawing.Point startPos = new System.Drawing.Point(0, 50);
            //ps.SetLocation(startPos);
            //ps.SetSize(new System.Drawing.Size(900, 900));
            //ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            ////ps.Add("Add Elemenhost", form1);
            //ps.AddVisual("Ribbon", mainWindow);
        }

        public void Terminate()
        {
            
        }
    }
}
