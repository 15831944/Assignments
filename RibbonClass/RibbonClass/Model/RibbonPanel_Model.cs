using Bricscad.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonClass.Model
{
    public class RibbonPanel_Model  { }
    public class RibbonPanelCustom : INotifyPropertyChanged
    {
        public String Tab { get; set; }
        public bool IsEnabled { get; set; }
        public RibbonPanelSourceCustom RibbonPanelSourceCustom { get; set; }

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

