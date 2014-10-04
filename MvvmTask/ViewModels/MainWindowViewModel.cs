using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTask.ViewModels
{
    public class MainWindowViewModel
    {
        public List<string> TestList { get; set; }

        public MainWindowViewModel()
        {
            TestList = new List<string>();
            TestList.Add("hello");
        }
    }
}
