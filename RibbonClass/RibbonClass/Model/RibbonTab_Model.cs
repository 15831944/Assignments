using Bricscad.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricscadApp;
using BricscadDb;
using Bricscad.ApplicationServices;

namespace RibbonClass.Model
{
    public class RibbonTab_Model { }
    public sealed class RibbonTabCustom : INotifyPropertyChanged
    {
        public String Name { get; set; }
        public String ID { get; set; }
        public String Title { get; set; }
        public ObservableCollection<RibbonPanelCustom> ribbonPanelCustoms { get; set; }
        public bool IsEnabled { get; set; }
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
