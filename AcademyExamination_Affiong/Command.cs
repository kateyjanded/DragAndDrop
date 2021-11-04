using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcademyExamination_Affiong
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action Action;
        private Func<bool> CanbeExecuted;

        public Command(Action action, Func<bool> canExecute)
        {
            Action = action;
            CanbeExecuted = canExecute;
        }
        public Command(Action action)
        {
            Action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (Action != null)
            {
                Action();
            }
        }
    }
}
