using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChange("Name");
                }
            }
        }

        //public ObservableCollection<Student> Students
        //{
        //    //get { return StudentsList; }
        //}

        public ObservableCollection<VMStudent> StudentsList { get; set; }

        public MainWindowViewModel()
        {
            StudentsList = new ObservableCollection<VMStudent>();
            Model model = new Model();
            foreach (var item in model.students)
            {
                StudentsList.Add(new VMStudent() { Name = item.Name });
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /* TODO : UPDATE DATA IN LIST ON VIEWMODEL , PUSH IT TO MODEL */
    }
}
