using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;

namespace TodoApp.Commands
{
    class CreateTaskCommad : ICommand
    {
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

 /*           if (parameter is TaskListViewModel taskList)
            {
                taskList.Tasks.Add(new TaskListViewModel() { Name = taskList.Name, IsDone = false})
            }
 */
        }
    }
}
