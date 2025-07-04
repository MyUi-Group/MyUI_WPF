using  MyUi.Global;
using MyUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUiDemo.ViewModels
{
    internal class ListBoxPageViewModel : BindableBase
    {
 
        private ObservableCollection<string>  _TestList=new ObservableCollection<string>();

        public ObservableCollection<string> TestList
        {
            get { return _TestList; }
            set { SetProperty(ref _TestList, value); }
        }
        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));

     

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));



        public ListBoxPageViewModel() 
        {
        
        }

        private void ExecuteLoadchCommand(object obj)
        {
            for (int i=0;i<100;i++) 
            {
                TestList.Add($"这是第{i}测试数据");
            }
        }

        private void ExecuteUnLoadCommand(object obj)
        {

        }

    }
}
