using System;
using System.Windows;
using System.Windows.Input;

namespace MVVMSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ChangeTextCommand : ICommand
    {
        public MainWindowViewModel mwv;
        private int i = 0;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            i++;
            mwv.MyString = "Hey you Clicked me " + i.ToString();
        }
    }
}
