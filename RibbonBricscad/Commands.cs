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
    // The basic attribute we'll use to tag the methods/commands to place

    // on the palette



    //[AttributeUsage(AttributeTargets.Method)]

    //public class PaletteMethod : Attribute { }



    //public class Commands

    //{

    //    private static PaletteSet _ps = null;



    //    // Our main command to display a palette. This is flagged to be included

    //    // on the palette, too, which is a bit silly, but harmless (as the

    //    // command doesn't do anything if the palette is already available)



    //    //[PaletteMethod]

    //    //[CommandMethod("PC")]

    //    //public void PaletteCcommands()

    //    //{

    //    //    if (_ps == null)

    //    //    {

    //    //        var doc = Application.DocumentManager.MdiActiveDocument;

    //    //        if (doc == null) return;

    //    //        var ed = doc.Editor;



    //    //        // We're going to take a look at the various methods in this module



    //    //        var asm = Assembly.GetExecutingAssembly();

    //    //        var type = asm.GetType("ModelessDialogs.Commands");

    //    //        if (type == null)

    //    //        {

    //    //            ed.WriteMessage("\nCould not find the command class.");

    //    //            return;

    //    //        }



    //    //        // We'll create a sequence of buttons for each callable method



    //    //        var bs = new List<Button>();

    //    //        var i = 1;



    //    //        // Loop over each method



    //    //        foreach (var m in type.GetMethods())

    //    //        {

    //    //            var cmdName = "";

    //    //            var palette = false;



    //    //            // And then all of its attributes



    //    //            foreach (var a in m.CustomAttributes)
    //    //            {
    //    //                // Check whether we have a command and/or a "palette" attb



    //    //                if (a.AttributeType.Name == "CommandMethodAttribute")

    //    //                {

    //    //                    cmdName = (string)a.ConstructorArguments[0].Value;

    //    //                }

    //    //                else if (a.AttributeType.Name == "PaletteMethod")

    //    //                {

    //    //                    palette = true;

    //    //                }

    //    //            }

    //    //            // If we have a palette attb, then one way or another it'll be
    //    //            // added to the palette
    //    //            if (palette)
    //    //            {
    //    //                // Create our button and give it a position
    //    //                var b = new Button();
    //    //                //b.SetBounds(50, 40 * i, 100, 30);
    //    //                // If no command name was found, use the method name and call the
    //    //                // function directly in the session context
    //    //                if (String.IsNullOrEmpty(cmdName))
    //    //                {
    //    //                    b.Content = m.Name;
    //    //                    b.Click +=
    //    //                      (s, e) =>
    //    //                      {
    //    //                          var b2 = (Button)s;
    //    //                          var mi = type.GetMethod(b2.Content);
    //    //                          if (mi != null)
    //    //                          {
    //    //                // Use reflection to call the method with no arguments
    //    //                mi.Invoke(this, null);
    //    //                          }
    //    //                      };
    //    //                }
    //    //                else
    //    //                {
    //    //                    // Otherwise we use the command name as the button text and
    //    //                    // execute the command in the command context asynchronously
    //    //                    b.Content = cmdName;
    //    //                    b.Click +=
    //    //                      async (s, e) =>
    //    //                      {
    //    //                          var dm = Application.DocumentManager;
    //    //                          var doc2 = dm.MdiActiveDocument;
    //    //                          if (doc2 == null) return;
    //    //            // We could also use SendStringToExecute for older versions
    //    //            // doc2.SendStringToExecute(
    //    //            //   "_." + cmdName + " ", false, false, true
    //    //            // );
    //    //            var ed2 = doc2.Editor;
    //    //                          await dm.ExecuteInCommandContextAsync(
    //    //              async (obj) =>
    //    //                          {
    //    //                              await ed2.CommandAsync("_." + cmdName);
    //    //                          },
    //    //              null
    //    //            );
    //    //                      };
    //    //                }
    //    //                bs.Add(b);
    //    //                i++;
    //    //            }
    //    //        }
    //    //        // Create a user control and add all our buttons to it
    //    //        var uc = new WinForms.UserControl();
    //    //        uc.Controls.AddRange(bs.ToArray());
    //    //        // Create a palette set and add a palette containing our control
    //    //        _ps = new PaletteSet("PC", new Guid("87374E16-C0DB-4F3F-9271-7A71ED921566"));
    //    //        _ps.Add("CMDPAL", uc);
    //    //        _ps.MinimumSize = new Size(200, (i + 1) * 40);
    //    //        _ps.DockEnabled = (DockSides)(DockSides.Left | DockSides.Right);
    //    //    }
    //    //    _ps.Visible = true;
    //    //}
    //}

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
            //var menuGroups = app.MenuGroups;
            ////menuGroups.Item(0).Unload();
            
            //AcadMenuGroup menuGroup = menuGroups.Load(loadCUIpath);
            //menuGroup.Save(AcMenuFileType.acMenuFileSource);
            //if (RibbonServices.RibbonPaletteSet == null)
            //{
            //    var PS = RibbonServices.CreateRibbonPaletteSet();

            //}

            //AcadPreferences acadPreferences = app.Preferences;
            //AcadPreferencesFiles acadPreferencesFiles = acadPreferences.Files;
            //string path = acadPreferencesFiles.MenuFile;
            //editor().WriteMessage(path + "\n");
            //var MenuGroups = app.MenuGroups;
            //if (MenuGroups.Count == 1)
            //{
            //    MenuGroups.Item(0).Unload();
            //}
            //for (int i = 0; i < MenuGroups.Count; i++)
            //{
            //    editor().WriteMessage(MenuGroups.Item(i).Name.ToString() + "\n");
            //}
            //var Toolbars = MenuGroups.Item(0).Toolbars;
            //for (int i = 0; i < Toolbars.Count; i++)
            //{
            //    editor().WriteMessage(Toolbars.Item(i).Name.ToString() + "\n");
            //}
        }

        public void Terminate()
        {
            
        }

        [CommandMethod("AddRightToolbar")]
        public static void AddRightToolbar()
        {
            //UserControl1 uc = new UserControl1();
            //uc.InitUI();
            var menuGroups = app.MenuGroups;
            bool CheckExist = false;
            for (int i = 0; i < menuGroups.Count; i++)
            {
                if (menuGroups.Item(i).Name == "CUSTOMCUI")
                {
                    CheckExist = true;
                }
            }
            if (!CheckExist)
            {
                var menuGroup = menuGroups.Load(loadCUIpath);
                //var toolBar = menuGroup.Toolbars.Item(0);
                //foreach (AcadToolbarItem item in toolBar)
                //{
                //    string SmallImage = "";
                //    string LargeImage = "";
                //    if (toolBar.LargeButtons == true)
                //    {
                //        LargeImage = CombinePath(imagepath, item.Name + ".bmp");
                //    }
                //    else
                //    {
                //        SmallImage = CombinePath(imagepath, item.Name + ".bmp");
                //    }
                //    if (item.Name != "")
                //    {
                //        item.SetBitmaps(SmallImage, LargeImage);
                //    }
                //}
                menuGroup.Save(AcMenuFileType.acMenuFileSource);
            }
            // ToDO
            //else
            //{
            //    var menuGroup = menuGroups.Item(0);
            //    var toolBar = menuGroup.Toolbars.Item(0);
            //    foreach (AcadToolbarItem item in toolBar)
            //    {
            //        if (item.Name != "")
            //        {
            //            item.SetBitmaps(item.Name, item.Name);
            //        }
            //    }
            //}
        }

        [CommandMethod("AddBottomToolbar")]
        public static void AddBottomToolbar()
        {
            //UserControl2 uc = new UserControl2();
            PaletteSet ps = new PaletteSet("Bottom Toolbar", new Guid("87374E16-C0DB-4F3F-9271-7A71ED921566"))
            {
                Dock = DockSides.Bottom,
                KeepFocus = true,
                //Size = new System.Drawing.Size((int)uc.width, (int)uc.height),
            };
            //System.Drawing.Point startPos = new System.Drawing.Point(50, 50);
            //ps.SetLocation(startPos);
            ps.TitleBarLocation = PaletteSetTitleBarLocation.Left;
            var uc2 = new System.Windows.Forms.Control();
            uc2.Height = 26;
            List<InputUI> UIInputList;
            List<InputUI> inputs = new List<InputUI>();
            inputs.Add(new InputUI() { text = "New Model" });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "..." });
            inputs.Add(new InputUI() { text = "License Days Left" });
            inputs.Add(new InputUI() { text = "..." });
            UIInputList = inputs;
            System.Windows.Forms.StatusBar statusBar = new System.Windows.Forms.StatusBar();
            statusBar.Margin = new System.Windows.Forms.Padding(0);
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#038e96");
            //statusBar.Background = brush;
            statusBar.Name = "StatusBar";

            //Grid.ColumnSpan = "2" Height = "Auto"

            //DockPanel dockPanel = new DockPanel();
            //dockPanel.HorizontalAlignment = HorizontalAlignment.Left;
            //dockPanel.Children.Add(new Label() { Content = UIInputList[0].text, HorizontalAlignment = HorizontalAlignment.Left, Foreground = new SolidColorBrush(Colors.White), FontSize = 9 });
            //WrapPanel wrapPanel = new WrapPanel() { Name = "WrapPanel", HorizontalAlignment = HorizontalAlignment.Right, Height = 26 };
            //dockPanel.Children.Add(wrapPanel);
            //foreach (var item in UIInputList)
            //{
            //    wrapPanel.Children.Add(new Label() { Content = item.text, Foreground = new SolidColorBrush(Colors.White), FontSize = 9 });
            //}
            //statusBar.ShowPanels = true;
            //statusBar.Panels.AddRange(dockPanel);
            //statusBar.Panels.Add(dockPanel);
            //statusBar.Items.Add(dockPanel);
            //System.Windows.Forms.StatusBarPanel statusBarPanel = new System.Windows.Forms.StatusBarPanel();
            //statusBarPanel.Text = UIInputList[0].text;
            uc2.Controls.Add(statusBar);

            StatusStrip statusStrip = new StatusStrip();
            statusStrip.Margin = new Padding(0);
            statusStrip.Name = "StatusStip";
            statusStrip.SuspendLayout();
            var toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {toolStripStatusLabel1});
            toolStripStatusLabel1.Text = UIInputList[0].text;
            uc2.Controls.Add(statusStrip);
            //statusStrip.BackColor = new System.Drawing.Color();
            //Grid grid = new Grid();
            //grid.Name = "parent";
            //grid.Children.Add()

            
            ps.Add("Test", uc2);
            //ps.AddVisual("Ribbon", uc);
            //var uc2 = new WinForms
            //ps.Add("Ribbon", uc2);
            
            var PSSize = new System.Drawing.Size(1000, 26);
            ps.MinimumSize = PSSize;
            ps.DockEnabled = (DockSides)(DockSides.Left | DockSides.Right);
            ps.Size = new System.Drawing.Size(PSSize.Width, PSSize.Height);
            ps.Size = PSSize;
            ps.Visible = true;
        }

        [CommandMethod("Test")]
        public static void Test()
        {
            CustomUI customUI = new CustomUI();
            customUI.Init();
        }

        [CommandMethod("Sh")]
        public static void Sh()
        {
            RibbonPanelSource ribbonPanelSource = new RibbonPanelSource();
            ribbonPanelSource.Id = "customMenuRibbonSubPanelSource";
            ribbonPanelSource.Title = "customMenu RibbonSubPanelSource";

            

            RibbonRowPanel rowPanel = new RibbonRowPanel();
            rowPanel.Id = "customMenuRibbonRowPanel";
            foreach (RibbonToggleButton btn in CustomRibbonToggleButton.GetTabPanelButtons())
            {
                rowPanel.Items.Add(btn);
            }

            RibbonPanelSource srcPanel = new RibbonPanelSource();
            srcPanel.Id = "customMenuRibbonPanelSource";
            srcPanel.Title = "Tag Operations";
            srcPanel.Items.Add(rowPanel);

            RibbonPanel Panel = new RibbonPanel();
            Panel.Source = srcPanel;
            

            RibbonTab Tab = new RibbonTab();
            Tab.Id = "customMenuRibbonTab";
            Tab.Title = "customMenu";
            Tab.Panels.Add(Panel);

            RibbonControl ribbonControl = ComponentManager.Ribbon;
            ribbonControl.Tabs.Add(Tab);           
        }
    }
}
