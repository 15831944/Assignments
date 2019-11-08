using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Runtime;
using Bricscad.Windows;
using BricscadApp;
using Bricscad.ApplicationServices;
using Bricscad.EditorInput;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(RibbonBricscad.Commands))]


//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(RibbonBricscad.Commands))]

namespace RibbonBricscad
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {

        }

        public void Terminate()
        {
            var app = Bricscad.ApplicationServices.Application.AcadApplication as AcadApplication;
            var menuGroups = app.MenuGroups;
        }

        [CommandMethod("AddRightToolbar")]
        public static void AddRightToolbar()
        {
            UserControl1 uc = new UserControl1();
            uc.InitUI();
        }

        [CommandMethod("AddBottomToolbar")]
        public static void AddBottomToolbar()
        {
            UserControl2 uc = new UserControl2();
            PaletteSet ps = new PaletteSet("Bottom Toolbar")
            {
                Style = PaletteSetStyles.NameEditable |
               PaletteSetStyles.ShowPropertiesMenu |
               PaletteSetStyles.ShowAutoHideButton |
               PaletteSetStyles.ShowCloseButton |
               PaletteSetStyles.Snappable,
                Visible = true,
                Dock = DockSides.Bottom,
                KeepFocus = true,
                MinimumSize = new System.Drawing.Size((int)uc.width, (int)uc.height),
                Size = new System.Drawing.Size((int)uc.width, (int)uc.height)
            };
            //System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            //ps.SetLocation(startPos);
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            ps.AddVisual("Ribbon", uc);
        }

        [CommandMethod("Test")]
        public static void Test()
        {
            CustomUI customUI = new CustomUI();
            customUI.Init();
        }
    }
}
