using System;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    //public class RelayCommand : ICommand
    //{
    //    private Action<object> execute;
    //    private Func<object, bool> canExecute;

    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Execute(object parameter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public event EventHandler CanExecuteChanged
    //    //{
    //    //    add { CommandManager.RequerySuggested += value; }
    //    //    remove { CommandManager.RequerySuggested -= value; }
    //    //}

    //    //public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    //    //{
    //    //    this.execute = execute;
    //    //    this.canExecute = canExecute;
    //    //}

    //    //public bool CanExecute(object parameter)
    //    //{
    //    //    return this.canExecute == null || this.CanExecute(parameter);
    //    //}

    //    //public void Execute(object parameter)
    //    //{
    //    //    this.execute(parameter);
    //    //}

    //    //private RelayCommand _executecommand;
    //    //public ICommand ExecuteCommand2
    //    //{
    //    //    get
    //    //    {
    //    //        if (_executecommand == null)
    //    //        {
    //    //            _executecommand = new RelayCommand(param => Execute2(), param => true);
    //    //        }
    //    //        return _executecommand;
    //    //    }
    //    //}

    //    //public virtual void Execute2()
    //    //{
    //    //    MessageBox.Show("Hello World");
    //    //}

    //    //public virtual bool CanExecute2()
    //    //{
    //    //    return true;
    //    //}

    //    //public void UpdateModel()
    //    //{
    //    //    var cmd1 = new RelayCommand(o => { MessageBox.Show("Hello World"); }, o => true);
    //    //}
    //}
}
