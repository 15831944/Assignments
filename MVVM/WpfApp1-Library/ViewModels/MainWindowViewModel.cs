﻿using Microsoft.TeamFoundation.MVVM;
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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string name = "test";
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

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    NotifyPropertyChange("Type");
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
    }
}
