using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using Bricscad.Windows;
using BricscadApp;

namespace RemoveToolbarsAndRibbons
{
    public class Toolbar
    {
        public static Editor editor()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            return document.Editor;
        }

    }
}
