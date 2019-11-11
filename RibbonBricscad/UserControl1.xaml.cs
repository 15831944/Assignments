using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BricscadApp;
using BricscadDb;
using Bricscad.ApplicationServices;
using Bricscad.Windows;
using System.Collections;
using System.Reflection;

namespace RibbonBricscad
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        AcadApplication app = Bricscad.ApplicationServices.Application.AcadApplication as AcadApplication;
        /* Current Path */
        static string CurrentDirectory = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        static string binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        static string cuiFile = "CustomUI.cui";
        static string loadCUIpath = CombinePath(binDebug, cuiFile);
        static string imagepath = CombinePath(binDebug, "res");
        

        public List<TBButton> ButtonList;

        public UserControl1()
        {
            InitializeComponent();
            ButtonList = new List<TBButton>();
            ButtonList.Add(new TBButton("Front View", "^c^c_-layer;m;InteriorWalls;;Mline", "Front View", GetImage("02_29-front view.ico"), GetImage("02_29-front view.ico")));
            ButtonList.Add(new TBButton("Back View", "_nearest", "Back View", GetImage("02_30-back view.ico"), GetImage("02_30-back view.ico")));
            ButtonList.Add(new TBButton("Top View", "adasdssa", "Top View", GetImage("02_31-top view.ico"), GetImage("02_31-top view.ico")));
            ButtonList.Add(new TBButton("Bottom View", "Command", "Bottom View", GetImage("02_32-bottom view.ico"), GetImage("02_32-bottom view.ico")));
        }
        public void InitUI()
        {
            var menuGroups = app.MenuGroups;
            var menuGroup = menuGroups.Load(loadCUIpath);
            var toolbars = menuGroup.Toolbars;
            AcadToolbar toolbar = toolbars.Add("Custom Toolbar");

            int i = 0;
            foreach (var items in ButtonList)
            {
                toolbar.AddToolbarButton(i, items.Name, items.HelpString, items.Macro);   
                //items.Name = items.Name;
                //items.HelpString = items.HelpString;
                //item.Macro = items.Macro;
                //item.SetBitmaps(GetImage(items.SmallIconName), GetImage(items.LargeIconName));
                //toolbar.AddToolbarButton(i, item.Name, item.HelpString, item.Macro).SetBitmaps(GetImage(item.SmallIconName),GetImage(item.LargeIconName));
                i++;
            }
            
            toolbar.Dock(AcToolbarDockStatus.acToolbarDockRight);
            toolbar.Float(0, 0, 3);
            toolbar.Visible = true;
            //toolbar.AddToolbarButton(-1 , "Front View", "Command", "Front View").SetBitmaps(CombinePath(imagepath, "02_29-front view.ico"), CombinePath(imagepath, "02_29-front view.ico"));
            //toolbar.AddToolbarButton(-1, "Back View", "Command", "Back View").SetBitmaps(CombinePath(imagepath, "02_30-back view.ico"), CombinePath(imagepath, "02_30-back view.ico"));
            //toolbar.AddToolbarButton(-1, "Top View", "Command", "Top View").SetBitmaps(CombinePath(imagepath, "02_31-top view.ico"), CombinePath(imagepath, "02_31-top view.ico"));
            //toolbar.AddToolbarButton(-1, "Bottom View", "Command", "Bottom View").SetBitmaps(CombinePath(imagepath, "02_32-bottom view.ico"), CombinePath(imagepath, "02_32-bottom view.ico"));
            //toolbar.AddToolbarButton(-1, "Left View", "Command", "Left View").SetBitmaps(CombinePath(imagepath, "02_33-left view.ico"), CombinePath(imagepath, "02_33-left view.ico"));
            //toolbar.AddToolbarButton(-1, "Right View", "Command", "Right View").SetBitmaps(CombinePath(imagepath, "02_34-right view.ico"), CombinePath(imagepath, "02_34-right view.ico"));
            //toolbar.AddToolbarButton(-1, "Iso Sw", "Command", "Iso Sw").SetBitmaps(CombinePath(imagepath, "03_20-iso sw.ico"), CombinePath(imagepath, "03_20-iso sw.ico"));
            //toolbar.AddToolbarButton(-1, "Iso Se", "Command", "Iso Se").SetBitmaps(CombinePath(imagepath, "03_21-iso se.ico"), CombinePath(imagepath, "03_21-iso se.ico"));
            //toolbar.AddToolbarButton(-1, "Iso Ne", "Command", "Iso Ne").SetBitmaps(CombinePath(imagepath, "03_22-iso ne.ico"), CombinePath(imagepath, "03_22-iso ne.ico"));
            //toolbar.AddToolbarButton(-1, "Iso Nw", "Command", "Iso Nw").SetBitmaps(CombinePath(imagepath, "03_23-iso nw.ico"), CombinePath(imagepath, "03_23-iso nw.ico"));
            //toolbar.AddToolbarButton(-1, "Zoom Di", "Command", "Zoom Di").SetBitmaps(CombinePath(imagepath, "Zoowin.ico"), CombinePath(imagepath, "Zoowin.ico"));
            //toolbar.AddToolbarButton(-1, "Zoom De", "Command", "Zoom De").SetBitmaps(CombinePath(imagepath, "Zoowin.ico"), CombinePath(imagepath, "Zoomin.ico"));
            //toolbar.AddSeparator(12);
            //toolbar.AddToolbarButton(-1, "Orbit", "Command", "Orbit").SetBitmaps(CombinePath(imagepath, "02_17-orbit.ico"), CombinePath(imagepath, "02_17-orbit.ico"));
            //toolbar.AddToolbarButton(-1, "Turnable Orbit", "Command", "Turnable Orbit").SetBitmaps(CombinePath(imagepath, "06-00-turntable orbit.ico"), CombinePath(imagepath, "06-00-turntable orbit.ico"));
            //toolbar.AddToolbarButton(-1, "3dpan", "Command", "3dpan").SetBitmaps(CombinePath(imagepath, "3dpan.ico"), CombinePath(imagepath, "3dpan.ico"));
            //toolbar.AddToolbarButton(-1, "Zoom Mouse", "Command", "Zoom Mouse").SetBitmaps(CombinePath(imagepath, "02_19-zoom mouse.ico"), CombinePath(imagepath, "02_19-zoom mouse.ico"));
            //toolbar.AddSeparator(17);
            //toolbar.AddToolbarButton(-1, "Zoom Mouse", "Command", "Zoom Mouse").SetBitmaps(CombinePath(imagepath, "02_19-zoom mouse.ico"), CombinePath(imagepath, "02_19-zoom mouse.ico"));
            //toolbar.AddToolbarButton(-1, "Select Rubberband", "Command", "Select Rubberband").SetBitmaps(CombinePath(imagepath, "02_22-select by rubberband.ico"), CombinePath(imagepath, "02_22-select by rubberband.ico"));
            //toolbar.AddToolbarButton(-1, "Select Clicking", "Command", "Select Clicking").SetBitmaps(CombinePath(imagepath, "02_21-select by clicking.ico"), CombinePath(imagepath, "02_21-select by clicking.ico"));
            //toolbar.AddToolbarButton(-1, "QQ", "Command", "QQ").SetBitmaps(CombinePath(imagepath, "02_21-select by clicking.ico"), CombinePath(imagepath, "02_21-select by clicking.ico"));
            //toolbar.AddSeparator(22);
            //toolbar.AddToolbarButton(-1, "Cutting Plane", "Command", "Cutting Plane").SetBitmaps(CombinePath(imagepath, "07_22-Cutting Plane Z.ico"), CombinePath(imagepath, "07_22-Cutting Plane Z.ico"));
            //toolbar.AddToolbarButton(-1, "Translucent", "Command", "Translucent").SetBitmaps(CombinePath(imagepath, "02_27-translucent.ico"), CombinePath(imagepath, "02_27-translucent.ico"));
            //toolbar.AddToolbarButton(-1, "Show Nozzles", "Command", "Show Nozzles").SetBitmaps(CombinePath(imagepath, "01_06-Show Nozzles.ico"), CombinePath(imagepath, "01_06-Show Nozzles.ico"));
            //toolbar.AddToolbarButton(-1, "Hoops Plot Refresh", "Command", "Hoops Plot Refresh").SetBitmaps(CombinePath(imagepath, "PV_Hoops_Plot_Refresh.ico"), CombinePath(imagepath, "PV_Hoops_Plot_Refresh.ico"));
            menuGroup.Save(AcMenuFileType.acMenuFileSource);
        }

        public static string CombinePath(string path1, string path2)
        {
            string temp = System.IO.Path.Combine(path1, path2);
            return temp;
        }

        public static string GetImage(string ImageSource)
        {
            return CombinePath(imagepath, ImageSource);
        }

    }
}
