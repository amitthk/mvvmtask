using MvvmTask.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTask.ViewModels
{
    public class MainWindowViewModel
    {

        public ICommand AddTodoCmd { get; private set; }
        public ICommand ListTodosCmd { get; private set; }
        public ICommand UpdateTodoCmd { get; private set; }
        public ICommand LoadTodoCmd { get; private set; }
        public ICommand DeleteTodoCmd { get; private set; }


        public ObservableCollection<TodoViewModel> TodoList { get; set; }
        TodoServiceClient _todoServiceClient;


        public MainWindowViewModel()
        {
            _todoServiceClient = new TodoServiceClient("NetTcpBinding_ITodoService");
            TodoList = new ObservableCollection<TodoViewModel>();

            loadTodoList();

            UpdateTodoCmd = new RelayCommand(ExecUpdateTodo, CanUpdateTodo);
            DeleteTodoCmd = new RelayCommand(ExecDeleteTodo, CanDeleteTodo);
            LoadTodoCmd = new RelayCommand(ExecLoadTodo, CanLoadTodo);
            ListTodosCmd = new RelayCommand(ExecListTodos, CanListTodos);
            AddTodoCmd = new RelayCommand(ExecAddTodo, CanAddTodo);

        }

        private void loadTodoList()
        {
            //Dummy
            var tid = _todoServiceClient.Add(new Service.Domain.Todo() { AddedBy = "Amit", Title = "First todo", Text = "this is first todo" });

            var lstTodos = _todoServiceClient.List();
            if ((lstTodos != null) && (lstTodos.Length > 0))
            {
                foreach (var item in lstTodos)
                {
                    TodoList.Add(new TodoViewModel(item));
                }
            }
        }


        //This goes in Initialization/constructor
        private void ExecDeleteTodo(object obj)
        {

        }

        private bool CanDeleteTodo(object obj)
        {
            return (true);
        }
        //This goes in Initialization/constructor
        private void ExecLoadTodo(object obj)
        {

        }

        private bool CanLoadTodo(object obj)
        {
            return (true);
        }
        //This goes in Initialization/constructor
        private void ExecUpdateTodo(object obj)
        {

        }

        private bool CanUpdateTodo(object obj)
        {
            return (true);
        }
        //This goes in Initialization/constructor
        private void ExecListTodos(object obj)
        {

        }

        private bool CanListTodos(object obj)
        {
            return (true);
        }
        //This goes in Initialization/constructor
        private void ExecAddTodo(object obj)
        {

        }

        private bool CanAddTodo(object obj)
        {
            return (true);
        }
    }
}
