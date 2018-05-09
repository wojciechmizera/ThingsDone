using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThingsDone
{
    public class RelayCommand : ICommand
    {
        Action mAction;

        Func<bool> canExecute;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action mAction, Func<bool> CanExecute)
        {
            this.mAction = mAction ?? throw new ArgumentNullException(nameof(mAction));
            this.canExecute = CanExecute ?? throw new ArgumentNullException(nameof(CanExecute));
        }

        public bool CanExecute(object parameter) => canExecute();

        public void Execute(object parameter) => mAction();
        
    }

}
