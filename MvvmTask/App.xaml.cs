using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Common.BootStrapper.Instance.Bootstrap(this,e);
            base.OnStartup(e);
        }

        

        protected override void OnExit(ExitEventArgs e)
        {
            Common.BootStrapper.Instance.ShutDown(this, e);
            base.OnExit(e);
        }
    }
}
