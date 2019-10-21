using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
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
            //Application.ShowAlertDialog("The commands class is Initialized");
            if (RibbonServices.RibbonPaletteSet == null)
                RibbonServices.CreateRibbonPaletteSet();
            RemoveRibbon();
            RemoveToolbar();
            //Application.ShowAlertDialog(toolbar.Count.ToString());
        }

        public void Terminate()
        {
            //Application.ShowAlertDialog("The commands class is Terminated");
        }

        // This attribute marks this function as being command line callable 
        [CommandMethod("samp01")]
        static public void RemoveRibbon()
        {
            Ribbon.RemoveRibbons();
        }

        [CommandMethod("samp02")]
        public static void RemoveToolbar()
        {
            var app = Application.AcadApplication as AcadApplication;
            if (app == null)
            {
                throw new NullReferenceException("Could Not Get Application");
            }
            try
            {
                var MenuGroups = app.MenuGroups;
                var Toolbars = MenuGroups.Item(0).Toolbars;
                for (int i = 0; i < Toolbars.Count; i++)
                {
                    if (Toolbars.Item(i).Name.ToString() == "Standard")
                    //editor().WriteMessage(Toolbars.Item(i).Name.ToString() + "\n");
                    {
                        Toolbars.Item(i).Delete();
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog(string.Format("\nError: {0}\nStackTrace: {1}"
                    , ex.Message, ex.StackTrace));
            }
        }

        public static Editor editor()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }

        
    }
}
