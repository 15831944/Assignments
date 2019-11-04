using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        string name = "Demo";

        string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != name)
                {
                    this.name = value;
                    this.NotifyPropertyChange("Name");
                }
            }
        }
        public MainWindowViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
