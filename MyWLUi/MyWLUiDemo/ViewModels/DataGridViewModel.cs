using MyWLUi.Global;
using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    internal class DataGridViewModel : BindableBase
    {
        #region
        public List<object> _Datas { get; set; }
        private List<object> _Items;
        public List<object> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }

        private int _PageSize = 10;
        public int PageSize
        {
            get { return _PageSize; }
            set { SetProperty(ref _PageSize, value); }
        }

        private int _PageIndex = 1;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { SetProperty(ref _PageIndex, value); }
        }


        private int _PageCount = 1000;

        public int PageCount
        {
            get
            {
                return _PageCount;
            }
            set
            {
                SetProperty(ref _PageCount, value);
            }
        }

        private ObservableCollection<int> _Limits;

        public ObservableCollection<int> Limits
        {
            get { return _Limits; }
            set { SetProperty(ref _Limits, value); }
        }


        #endregion

        #region cmd
        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));

   

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));


        private DelegateCommand _PageUpdatedCommand;
        public DelegateCommand PageUpdateCommand =>
            _PageUpdatedCommand ?? (_PageUpdatedCommand = new DelegateCommand(ExecutePageUpdated));


        private DelegateCommand _HeadCheckCommand;
        public DelegateCommand HeadCheckCommand =>
            _HeadCheckCommand ?? (_HeadCheckCommand = new DelegateCommand(HeadCheckMethod));

    

        private DelegateCommand _HeadUnCheckCommand;
        public DelegateCommand HeadUnCheckCommand =>
            _HeadUnCheckCommand ?? (_HeadUnCheckCommand = new DelegateCommand(HeadUnCheckMethod));





        #endregion

        public DataGridViewModel() 
        {
            
        }

        private void ExecutePageUpdated(object obj)
        {
            MessageControl.Success($"成功跳转到{obj}页,在此方法处理分页数据加载逻辑", "Message");
        }

        private void ExecuteLoadchCommand(object obj)
        {
            _Datas = new List<object>();
            for (int i = 1; i <= PageCount; i++)
            {
                int _state = i % 2 == 0 ? 1 : 0;
                _Datas.Add(new { Court = $"测试{i}", IsSelected = i % 2 == 0, Name = $"未知{i}", UpdateTime = DateTime.Now, State = _state });
            }
            DoExecutePageUpdatedCommand(PageIndex);
        }
        private void ExecuteUnLoadCommand(object obj)
        {
          
        }

        void DoExecutePageUpdatedCommand(object obj)
        {
            Limits = new ObservableCollection<int>();
            Limits.Add(10);
            Limits.Add(15);
            Limits.Add(20);
            PageIndex = int.Parse(obj.ToString());
            Items = _Datas.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }

        private void HeadCheckMethod(object obj)
        {
            MessageControl.Success($"在此处理全选逻辑", "Message");
        }

        private void HeadUnCheckMethod(object obj)
        {
            MessageControl.Success($"在此处理非全选逻辑", "Message");
        }
    }
}
