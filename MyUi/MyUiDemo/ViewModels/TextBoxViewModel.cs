using  MyUi.Global;
using MyUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUiDemo.ViewModels
{
    internal class TextBoxViewModel : BindableBase
    {
        private DelegateCommand _SearchCommand;
        public DelegateCommand SearchCommand =>
            _SearchCommand ?? (_SearchCommand = new DelegateCommand(ExecuteSearchCommand));


        public TextBoxViewModel() 
        {
        
        }

        private void ExecuteSearchCommand(object obj)
        {
            MessageControl.Success("成功执行查询命令", "Message");
        }
    }
}
