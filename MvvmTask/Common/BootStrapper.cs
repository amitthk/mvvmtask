using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MvvmTask.Service;

namespace MvvmTask.Common
{
    class BootStrapper
    {
        private static ServiceHost _host;

        internal static void Bootstrap(App app, System.Windows.StartupEventArgs e)
        {
            //do something for the app here
            _host = new ServiceHost(typeof(TodoService));
            try
            {
                _host.Open();
            }
            catch (Exception exc)
            {
                _host.Abort();
                throw (exc);
            }
        }

        internal static void ShutDown(App app, System.Windows.ExitEventArgs e)
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
