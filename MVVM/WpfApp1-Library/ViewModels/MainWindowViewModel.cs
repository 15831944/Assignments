using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
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

        public ObservableCollection<VMStudent> StudentsList { get; set; }

        private ICommand mButtonCommand;
        public ICommand DoSomethingCommand
        {
            get
            {
                if (mButtonCommand == null)
                {
                    mButtonCommand = new RelayCommand(Action => TestFunc(), predicate => CanTest());
                }
                return mButtonCommand;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (mButtonCommand == null)
                {
                    mButtonCommand = new RelayCommand(Action => ExitFunc(), predicate => CanTest());
                }
                return mButtonCommand;
            }
        }

        public string Error
        {
            get
            {
                return "....";
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    Regex regex = new Regex("[^a-zA-Z]+");
                    if (regex.IsMatch(this.name))
                    {
                        result = "Error";
                    }
                }
                return result;
            }
        }

        public void ExitFunc()
        {
            MessageBox.Show("Enter ");
        }

        public bool CanTest()
        {
            return true;
        }

        private void TestFunc()
        {
            MessageBox.Show("Hello ");
        }

        public MainWindowViewModel()
        {
            StudentsList = new ObservableCollection<VMStudent>();
            Model model = new Model();
            foreach (var item in model.students)
            {
                StudentsList.Add(new VMStudent() { Name = item.Name });
            }
            //mButtonCommand = new Command();
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
