using Bricscad.ApplicationServices;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Teigha.Runtime;

// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(RemoveToolbarsAndRibbons.Commands))]


// this attribute marks this class, as a class having ExtensionApplication methods
// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(RemoveToolbarsAndRibbons.Commands))]

namespace RemoveToolbarsAndRibbons
{
    public class Commands : IExtensionApplication
    {
        public Commands()
        {
            // ctor
        }

        public void Initialize()
        {
            Application.ShowAlertDialog("The commands class is Initialized");
            if (RibbonServices.RibbonPaletteSet == null)
                RibbonServices.CreateRibbonPaletteSet();
            RemoveRibbon();
            Test();
            //Application.ShowAlertDialog(toolbar.Count.ToString());
        }

        public void Terminate()
        {
            Application.ShowAlertDialog("The commands class is Terminated");
        }

        // This attribute marks this function as being command line callable 
        [CommandMethod("samp01")]
        static public void RemoveRibbon()
        {
            Ribbon.RemoveRibbons();
        }

        static public void Test()
        {
            Toolbar toolbar = new Toolbar();
            Application.ShowAlertDialog(toolbar.Count.ToString());
            
        }
    }
}
