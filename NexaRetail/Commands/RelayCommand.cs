using System;
using System.Windows.Input;

namespace NexaRetail.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(
            Action execute,
            Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        // =========================================================
        // CAN EXECUTE CHANGED
        // =========================================================

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        // =========================================================
        // CAN EXECUTE
        // =========================================================

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute();
        }


        // =========================================================
        // EXECUTE
        // =========================================================

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute();
            }
        }


        // =========================================================
        // REFRESH COMMAND
        // =========================================================

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}