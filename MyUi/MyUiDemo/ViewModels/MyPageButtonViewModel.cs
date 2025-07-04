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
    internal class MyPageButtonViewModel : BindableBase
    {
        private ObservableCollection<int> _Limits;

        public ObservableCollection<int> Limits
        {
            get { return _Limits; }
            set { SetProperty(ref _Limits, value); }
        }

        #region cmd
        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));


        private DelegateCommand _PageUpdatedCommand;
        public DelegateCommand PageUpdateCommand =>
            _PageUpdatedCommand ?? (_PageUpdatedCommand = new DelegateCommand(ExecutePageUpdated));

        private void ExecutePageUpdated(object obj)
        {
            MessageControl.Success($"成功跳转到{obj},并触发刷新页面数据事件", "Message");
        }

        private void ExecuteLoadchCommand(object obj)
        {
            Limits = new ObservableCollection<int>();
            Limits.Add(10);
            Limits.Add(15);
            Limits.Add(20);
        }

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));

        private void ExecuteUnLoadCommand(object obj)
        {
            
        }





        #endregion
    }
}
