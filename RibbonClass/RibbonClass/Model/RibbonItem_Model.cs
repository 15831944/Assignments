using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bricscad.Windows;
using BricscadApp;
using BricscadDb;
using Bricscad.ApplicationServices;

namespace RibbonClass.Model
{
    public class RibbonItem_Model { }
    public class RibbonItemCustom : INotifyPropertyChanged
    {   
        
        public String Id { get; set; }
        public String ToolTip { get; set; }
        public String Text { get; set; }
        public String ImagePath { get; set; }
        public bool ExternalImage { get; set; }
        public bool IsVisible { get; set; }
        public bool IsInitialized { get; set; }
        public String Image { get; set; }
        public String LargeImage { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsEnabled { get; set; }
        public String ItemType { get; set; }
        public String Size { get; set; }
        public bool IsAutoSize { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
