using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonClass.Model
{
    public class RibbonPanelSource_Model {}
    public class RibbonPanelSourceCustom : INotifyPropertyChanged
    {
        public String Name { get; set; }
        public String Title { get; set; }
        public String Id { get; set; }
        public ObservableCollection<RibbonItemCustom> RibbonItemsCustom { get; set; }

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
