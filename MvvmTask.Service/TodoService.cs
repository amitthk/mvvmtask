using MvvmTask.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTask.Service
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        Guid Add(Todo todo);
        [OperationContract]
        void Delete(Guid id);
        [OperationContract]
        List<Todo> List();
        [OperationContract]
        bool Update(Todo todo);
        [OperationContract]
        Todo Get(Guid id);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
    public class TodoService:ITodoService
    {
        List<Todo> _lstDb = new List<Todo>();

        public Guid Add(Todo todo)
        {
            _lstDb.Add(todo);
            return (todo.Id);
        }

        public Todo Get(Guid id)
        {
            return (_lstDb.Where(x => x.Id == id).FirstOrDefault());
        }

        public void Delete(Guid id)
        {
            _lstDb.Remove(_lstDb.Where(x => x.Id == id).FirstOrDefault());
        }

        public List<Todo> List()
        {
            return (_lstDb);
        }

        public bool Update(Todo todo)
        {
            var itm = _lstDb.Where(x => x.Id == todo.Id).FirstOrDefault();
            if (itm == null)
            {
                return false;
            }
            else
            {
                _lstDb[_lstDb.IndexOf(itm)] = todo;
                return (true);
            }
        }
    }
}
