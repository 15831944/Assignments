using System;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class Command
    {
        //private Command updateCommand;
        //public Command UpdateCommand
        //{
        //    get
        //    {
        //        return new Command();
        //    }
        //}

        //private MainWindowViewModel obj;

        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested += value; }
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return _canExecute?.Invoke() ?? true;
        //}

        //public void Execute(object parameter)
        //{
        //    _execute?.Invoke();
        //}

        //public ICommand TestFunc()
        //{
        //    return new Command(() => { MessageBox.Show("Test"); }, () =>
        //    {
        //        return true;
        //    });
        //}

        //public bool CanExecute(object parameter)
        //{

        //    Student s = parameter as Student;
        //    return s != null && s.Name != null;
        //}

        //public event EventHandler CanExecuteChanged;

        //public void Execute(object parameter)
        //{
        //    MessageBox.Show(parameter.ToString());
        //}

        //public void RaiseCanExecuteChanged()
        //{
        //    var handler = CanExecuteChanged;
        //    if (handler != null)
        //    {
        //        handler(this, EventArgs.Empty);
        //    }
        //}
    }
}
