using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MvvmTask.Service.Domain
{
    [DataContract]
    public class Todo
    {
        private Guid _Id;
        private string _Title;
        private string _Text;
        private DateTime _CreateDt;
        private DateTime _DueDt;
        private int _EstimatedPomodori;
        private int _CompletedPomodori;
        private string _AddedBy;

        [DataMember]
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        [DataMember]        
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }



        [DataMember]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }


        [DataMember]
        public DateTime CreateDt
        {
            get { return _CreateDt; }
            set { _CreateDt = value; }
        }


        [DataMember]
        public DateTime DueDt
        {
            get { return _DueDt; }
            set { _DueDt = value; }
        }


        [DataMember]
        public int EstimatedPomodori
        {
            get { return _EstimatedPomodori; }
            set { _EstimatedPomodori = value; }
        }


        [DataMember]
        public int CompletedPomodori
        {
            get { return _CompletedPomodori; }
            set { _CompletedPomodori = value; }
        }




        [DataMember]
        public string AddedBy
        {
            get { return _AddedBy; }
            set { _AddedBy = value; }
        }



        public Todo()
        {
            _Id = Guid.NewGuid();
            _CreateDt = DateTime.Now;
            _EstimatedPomodori = 1;
            _CompletedPomodori = 0;
            _DueDt = DateTime.Today.AddDays(1);
        }
    }
}
