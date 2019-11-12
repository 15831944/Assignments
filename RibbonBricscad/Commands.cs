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
using System.Reflection;
using System.Windows.Controls;
using Bricscad.Ribbon;
using System.IO;
using BricscadDb;
using System.Drawing;
using RibbonBricscad.Properties;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using Application = Bricscad.ApplicationServices.Application;
using System.Windows.Forms;

//// this attribute marks this class, as a class that contains commands or lisp callable functions 
[assembly: CommandClass(typeof(RibbonBricscad.Commands))]


//// this attribute marks this class, as a class having ExtensionApplication methods
//// Initialize and Terminate that are called on loading and unloading of this assembly 
[assembly: ExtensionApplication(typeof(RibbonBricscad.Commands))]

namespace RibbonBricscad
{
    public class Commands : IExtensionApplication
    {
        static AcadApplication app = Bricscad.ApplicationServices.Application.AcadApplication as AcadApplication;
        static string binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        static string cuiFile = "RibbonBricscad.cui";
        static string loadCUIpath = CombinePath(binDebug, cuiFile);
        static string imagepath = CombinePath(binDebug, "res");

        public static string CombinePath(string path1, string path2)
        {
            string temp = System.IO.Path.Combine(path1, path2);
            return temp;
        }

        public static Editor editor()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }
        public void Initialize()
        {
            AddRightToolbar();
            AddBottomToolbar();
        }

        public void Terminate()
        {
            
        }

        [CommandMethod("AddRightToolbar")]
        public static void AddRightToolbar()
        {
            var menuGroups = app.MenuGroups;
            var menuGroup = menuGroups.Load(loadCUIpath);
            menuGroup.Save(AcMenuFileType.acMenuFileSource);
        }

        [CommandMethod("AddBottomToolbar")]
        public static void AddBottomToolbar()
        {
            UserControl2 uc = new UserControl2();
        }
    }
}
