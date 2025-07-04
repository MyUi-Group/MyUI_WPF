using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    internal class ComBoxViewModel : BindableBase
    {
        private ObservableCollection<string>  _TestItems=new ObservableCollection<string>();

        public ObservableCollection<string> TestItems
        {
            get { return _TestItems; }
            set { SetProperty(ref _TestItems, value); }
        }
        public ComBoxViewModel() 
        {
            for (int i=0;i<10;i++) 
            {
                TestItems.Add("测试数据"+(i+1));
            }
        }
    }
}
