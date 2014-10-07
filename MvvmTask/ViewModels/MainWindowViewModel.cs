using MvvmTask.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTask.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {

        public ICommand AddTodoCmd { get; private set; }
        public ICommand ListTodosCmd { get; private set; }
        public ICommand UpdateTodoCmd { get; private set; }
        public ICommand LoadTodoCmd { get; private set; }
        public ICommand DeleteTodoCmd { get; private set; }
        public ICommand NewTodoCmd { get; private set; }
        private readonly ICommand _CancelEditTodoCmd;

        public ICommand CancelEditTodoCmd { get { return (_CancelEditTodoCmd); } }
        public ObservableCollection<TodoViewModel> TodoList { get; set; }
        private TodoViewModel _SelectedTodo;
        private int _TodoListSelectedIndex;
        private EditMode _TodoListEditMode;

        public EditMode TodoListEditMode
        {
            get { return _TodoListEditMode; }
            set
            {
                if (_TodoListEditMode != value)
                {
                    _TodoListEditMode = value;
                    OnPropertyChanged("TodoListEditMode");
                }
            }
        }

        public int TodoListSelectedIndex
        {
            get { return _TodoListSelectedIndex; }
            set
            {
                if (_TodoListSelectedIndex != value)
                {
                    _TodoListSelectedIndex = value;
                    if (_TodoListSelectedIndex==-1)
                    {
                        TodoListEditMode = EditMode.Create;
                    }else
                    {
                        TodoListEditMode = EditMode.Update;
                    }
                    OnPropertyChanged("TodoListSelectedIndex");
                }
            }
        }

        public TodoViewModel SelectedTodo
        {
            get { return _SelectedTodo; }
            set
            {
                if ((null != value) && (_SelectedTodo != value))
                {
                    _SelectedTodo = value;
                    OnPropertyChanged("SelectedTodo");
                }
            }
        }

        TodoServiceClient _todoServiceClient;


        public MainWindowViewModel()
        {
            _todoServiceClient = new TodoServiceClient("NetTcpBinding_ITodoService");
            TodoList = new ObservableCollection<TodoViewModel>();

            loadTodoList();
            _TodoListSelectedIndex = -1;
            _SelectedTodo = new TodoViewModel();


            UpdateTodoCmd = new RelayCommand(ExecUpdateTodo, CanUpdateTodo);
            DeleteTodoCmd = new RelayCommand(ExecDeleteTodo, CanDeleteTodo);
            LoadTodoCmd = new RelayCommand(ExecLoadTodo, CanLoadTodo);
            ListTodosCmd = new RelayCommand(ExecListTodos, CanListTodos);
            AddTodoCmd = new RelayCommand(ExecAddTodo, CanAddTodo);
            NewTodoCmd = new RelayCommand(ExecNewTodo, CanNewTodo);
            _CancelEditTodoCmd = new RelayCommand(ExecCancelEditTodo, CanCancelEditTodo);

        }

        private void ExecNewTodo(object obj)
        {
            SelectedTodo = new TodoViewModel();
            TodoListSelectedIndex = -1;
        }

        [DebuggerStepThrough]
        private bool CanNewTodo(object obj)
        {
            return (true);
        }

        private void ExecCancelEditTodo(object obj)
        {
            //Todo: Add the functionality for CancelEditTodoCmd Here
            var ResetTodo = new TodoViewModel(_todoServiceClient.Get(Guid.Parse(SelectedTodo.Id)));
            TodoList[TodoList.IndexOf(SelectedTodo)] = ResetTodo;
            SelectedTodo = ResetTodo;
        }

        [DebuggerStepThrough]
        private bool CanCancelEditTodo(object obj)
        {
            //Todo: Add the checking for CanCancelEditTodo Here
            return (TodoListEditMode == EditMode.Update);
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
            System.Windows.MessageBoxResult confirmRunResult = System.Windows.MessageBox.Show("Are you sure you want to delete this todo?", "Delete Item?", System.Windows.MessageBoxButton.OKCancel);
            if (confirmRunResult == System.Windows.MessageBoxResult.Cancel)
            {
                return;
            }
            _todoServiceClient.Delete(Guid.Parse(SelectedTodo.Id));
            TodoList.Remove(SelectedTodo);
            resetSelectedTodo();
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
            bool isok= _todoServiceClient.Update(SelectedTodo._todo);
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
            Guid addedid= _todoServiceClient.Add(SelectedTodo._todo);
            SelectedTodo.Id = addedid.ToString();
            TodoList.Add(SelectedTodo);
            resetSelectedTodo();
        }

        private void resetSelectedTodo()
        {
            SelectedTodo = new TodoViewModel();
            TodoListSelectedIndex = -1;
        }

        private bool CanAddTodo(object obj)
        {
            return (true);
        }
    }
}
