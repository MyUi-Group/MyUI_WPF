using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    internal class ProcessBarViewModel : BindableBase
    {

        private int _CurrentValue = 0;

        public int CurrentValue
        {
            get
            {
                return _CurrentValue;
            }
            set
            {
                SetProperty(ref _CurrentValue, value);
            }
        }


        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));

    

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));


        public ProcessBarViewModel() { }

        private void ExecuteLoadchCommand(object obj)
        {
            Task.Run(async () => {
                while (true) 
                {
                    CurrentValue++;
                    await Task.Delay(200);
                }
            });
        }

        private void ExecuteUnLoadCommand(object obj)
        {
            
        }
    }
}
