﻿using MvvmTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTask.Common
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel { get { return new MainWindowViewModel(); } }
    }
}
