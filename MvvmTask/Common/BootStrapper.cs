using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MvvmTask.Service;
using System.ServiceModel.Description;

namespace MvvmTask.Common
{
    class BootStrapper
    {
        private static BootStrapper _instance;
        public static BootStrapper Instance { get {
            if (_instance==null)
            {
                _instance = new BootStrapper();
            }
            return (_instance);
        } }

        private BootStrapper()
        {
            _host = new ServiceHost(typeof(TodoService),new Uri("net.tcp://localhost:8889/todoservice"));
        }

        private static ServiceHost _host;

        public void Bootstrap(App app, System.Windows.StartupEventArgs e)
        {
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            //_host.Description.Behaviors.Add(smb);

            

            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem(state =>
                {
                    _host.Open();
                });
            }
            catch (Exception exc)
            {
                _host.Abort();
                throw (exc);
            }
        }

        public void ShutDown(App app, System.Windows.ExitEventArgs e)
        {
            try
            {
                _host.Close();
            }
            catch (Exception exc)
            {
                _host.Abort();
                throw (exc);
            }
        }
    }
}
