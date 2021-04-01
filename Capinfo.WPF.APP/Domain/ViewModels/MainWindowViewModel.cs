using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Capinfo.WPF.APP.ViewModels
{
    public class MainWindowViewModel
    {
        public DelegateCommand CloseCommand { get; set; }
        public MainWindowViewModel()
        {
            CloseCommand = new DelegateCommand(() =>
            {
                Application.Current.Shutdown();
            });
        }
    }
}
