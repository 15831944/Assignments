using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Bricscad.Windows;
using BricscadApp;
using BricscadDb;

namespace RibbonBricscad
{
    public class CustomUI
    {
        AcadApplication app = Bricscad.ApplicationServices.Application.AcadApplication as AcadApplication;
        /* Current Path */
        static string CurrentDirectory = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        static string binDebug = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        static string cuiFile = "CustomUI.cui";
        static string loadCUIpath = CombinePath(binDebug, cuiFile);
        static string imagepath = CombinePath(binDebug, "res");
        public List<TBButton> ButtonList;

        public CustomUI()
        {
            ButtonList = new List<TBButton>();
            ButtonList.Add(new TBButton("Front View", "", "", GetImage("02_29-front view.ico"), GetImage("02_29-front view.ico")));
            ButtonList.Add(new TBButton("Back View", "", "", GetImage("02_30-back view.ico"), GetImage("02_30-back view.ico")));
            ButtonList.Add(new TBButton("Top View", "", "", GetImage("02_31-top view.ico"), GetImage("02_31-top view.ico")));
            ButtonList.Add(new TBButton("Bottom View", "", "", GetImage("02_32-bottom view.ico"), GetImage("02_32-bottom view.ico")));

        }

        public void Init()
        {


            //RibbonControl rbnCtrl = ComponentManager.Ribbon;

            //rbnCtrl.ClearAllTabs();

            //// Init Panel Source
            //RibbonPanelSource srcPanel = new RibbonPanelSource();
            //srcPanel.Title = "";
            //srcPanel.Id = "CustomPanel";

            //RibbonPanel panel = new RibbonPanel();
            //panel.Source = srcPanel;

            //StackPanel wrapPanel = new StackPanel();
            //RibbonTab tab = new RibbonTab();
            //tab.Title = "Custom Tab";
            //tab.Id = "Custom Tab";
            //tab.Panels.Add(panel);
            //tab.Name = = "Custom Tab";


            //var menuGroups = app.MenuGroups;
            //var t = menuGroups.Item(0).Toolbars.Item(0);
            //var menuGroup = menuGroups.Load(loadCUIpath);
            //var toolbars = menuGroup.Toolbars;
            ////var toolbar = toolbars.Add("Right Toolbar");
            //AcadToolbar toolbar = toolbars.Add("Right Toolbar");

            //AcadToolbarItem item = toolbar.AddToolbarButton(0, ButtonList[0].Name, ButtonList[0].HelpString, ButtonList[0].Macro);
            //int i = 1;
            //foreach (var items in ButtonList)
            //{
            //    toolbar.AddToolbarButton(i, items.Name, items.HelpString, items.Macro);
            //    ////item.Name = items.Name;
            //    ////item.HelpString = items.HelpString;
            //    ////item.Macro = items.Macro;
            //    ////item.SetBitmaps(GetImage(items.SmallIconName), GetImage(items.LargeIconName));
            //    //toolbar.AddToolbarButton(i, item.Name, item.HelpString, item.Macro).SetBitmaps(GetImage(item.SmallIconName),GetImage(item.LargeIconName));
            //    i++;
            //}
            //toolbar.Dock(AcToolbarDockStatus.acToolbarDockRight);
            //toolbar.Float(0, 0, 3);
            //toolbar.Visible = true;
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
