using MyWLUi.Global;
using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    internal class MessageViewModel : BindableBase
    {
        private DelegateCommand _DefaultMessageCommand;
        public DelegateCommand DefaultMessageCommand =>
            _DefaultMessageCommand ?? (_DefaultMessageCommand = new DelegateCommand(ExecuteDefaultMessageCommand));


        private DelegateCommand _ErrorMessageCommand;
        public DelegateCommand ErrorMessageCommand =>
            _ErrorMessageCommand ?? (_ErrorMessageCommand = new DelegateCommand(ExecuteErrorMessageCommand));

        private DelegateCommand _WarnMessageCommand;
        public DelegateCommand WarnMessageCommand =>
            _WarnMessageCommand ?? (_WarnMessageCommand = new DelegateCommand(ExecuteWarnMessageCommand));

        private DelegateCommand _SuccessMessageCommand;
        public DelegateCommand SuccessMessageCommand =>
            _SuccessMessageCommand ?? (_SuccessMessageCommand = new DelegateCommand(ExecuteSuccessMessageCommand));



   

        public MessageViewModel() 
        {

        }

        private void ExecuteDefaultMessageCommand(object obj)
        {
            MessageControl.Default("这是一条默认Message", "Message");
        }

        private void ExecuteErrorMessageCommand(object obj)
        {
            MessageControl.Error("这是一条错误Message", "Message");
        }

        private void ExecuteWarnMessageCommand(object obj)
        {
            MessageControl.Warning("这是一条警告Message", "Message");
        }

        private void ExecuteSuccessMessageCommand(object obj)
        {
            MessageControl.Success("这是一条成功Message", "Message");
        }  
    }
}
