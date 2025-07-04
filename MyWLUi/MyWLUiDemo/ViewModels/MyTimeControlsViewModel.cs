using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    internal class MyTimeControlsViewModel : BindableBase
    {
        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));

        private void ExecuteLoadchCommand(object obj)
        {
            
        }

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));

        private void ExecuteUnLoadCommand(object obj)
        {
            
        }
    }
}
