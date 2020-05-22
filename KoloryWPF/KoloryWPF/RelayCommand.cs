using System;
using System.Diagnostics;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    #region Pola
    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;
    #endregion

    #region Konstruktor
    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion

    #region Skladowa ICommand
    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return _canExecute == null ? true : _canExecute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add
        {
            if (_canExecute != null) CommandManager.RequerySuggested += value;
        }
        remove
        {
            if (_canExecute != null) CommandManager.RequerySuggested -= value;
        }
    }
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    #endregion
}


