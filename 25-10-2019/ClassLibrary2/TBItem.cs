using Bricscad.ApplicationServices;
using Bricscad.EditorInput;
using Bricscad.Ribbon;
using BricscadApp;
using System;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Teigha.Runtime;
using Bricscad.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;

namespace ClassLibrary2
{
    public class TBItem : RibbonItem
    {
        public static RadButton radButton = new RadButton() { Content = "Test" };
        public RibbonButton ribbonButton = (RibbonButton)radButton;
    }
}
