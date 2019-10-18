using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using Bricscad.Windows;
using BricscadApp;

namespace RemoveToolbarsAndRibbons
{
    public class Ribbon
    {
        public static Editor editor()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }

        public static void RemoveRibbons()
        {
            RibbonControl ribbonControl = ComponentManager.Ribbon;
            foreach(var item in ribbonControl.Tabs)
            {
                ribbonControl.Tabs.Remove(item);
            }
        }
    }
}
