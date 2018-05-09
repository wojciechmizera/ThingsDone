using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThingsDone
{
    public class RelayParameterizedCommand : ICommand
    {
        Action<object> mAction;

        Func<bool> canExecute;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayParameterizedCommand(Action<object> mAction, Func<bool> CanExecute)
        {
            this.mAction = mAction ?? throw new ArgumentNullException(nameof(mAction));
            this.canExecute = CanExecute ?? throw new ArgumentNullException(nameof(CanExecute));
        }


        public bool CanExecute(object parameter) => canExecute();

        public void Execute(object parameter) => mAction(parameter);
    }
}
