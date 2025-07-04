using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.ViewModels
{
    internal class DrawWinPageViewModel : BindableBase
    {

        private bool _IsOpen = false;

        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }
            set
            {
                SetProperty(ref _IsOpen, value);
            }
        }


        private bool _IsLeftOpen = false;

        public bool IsLeftOpen
        {
            get
            {
                return _IsLeftOpen;
            }
            set
            {
                SetProperty(ref _IsLeftOpen, value);
            }
        }


        private bool _IsTopOpen = false;

        public bool IsTopOpen
        {
            get
            {
                return _IsTopOpen;
            }
            set
            {
                SetProperty(ref _IsTopOpen, value);
            }
        }

        private bool _IsBottomOpen = false;

        public bool IsBottomOpen
        {
            get
            {
                return _IsBottomOpen;
            }
            set
            {
                SetProperty(ref _IsBottomOpen, value);
            }
        }

        private DelegateCommand _LoadchCommand;
        public DelegateCommand LoadchCommand =>
            _LoadchCommand ?? (_LoadchCommand = new DelegateCommand(ExecuteLoadchCommand));

        private void ExecuteLoadchCommand(object obj)
        {
            Task.Run(async () => {
                await Task.Delay(3000);
                IsOpen = true;
                IsLeftOpen = true;
                IsTopOpen = true;
                IsBottomOpen = true;
            });
        }

        private DelegateCommand _UnLoadCommand;
        public DelegateCommand UnLoadCommand =>
            _UnLoadCommand ?? (_UnLoadCommand = new DelegateCommand(ExecuteUnLoadCommand));

        private void ExecuteUnLoadCommand(object obj)
        {
            
        }

        private DelegateCommand _ButtonCommand;
        public DelegateCommand ButtonCommand =>
            _ButtonCommand ?? (_ButtonCommand = new DelegateCommand(ExcuteButtonCommand));

        private void ExcuteButtonCommand(object obj)
        {
            if (IsOpen)
            {
                IsOpen = false;
            }
            else 
            {
                IsOpen = true;
            }
           
        }

        private DelegateCommand _ButtonLeftCommand;
        public DelegateCommand ButtonLeftCommand =>
            _ButtonLeftCommand ?? (_ButtonLeftCommand = new DelegateCommand(ExcuteButtonLeftCommand));

        private void ExcuteButtonLeftCommand(object obj)
        {
            if (IsLeftOpen)
            {
                IsLeftOpen = false;
            }
            else
            {
                IsLeftOpen = true;
            }

        }



        private DelegateCommand _ButtonTopCommand;
        public DelegateCommand ButtonTopCommand =>
            _ButtonTopCommand ?? (_ButtonTopCommand = new DelegateCommand(ExcuteButtonTopCommand));

        private void ExcuteButtonTopCommand(object obj)
        {
            if (IsTopOpen)
            {
                IsTopOpen = false;
            }
            else
            {
                IsTopOpen = true;
            }

        }


        private DelegateCommand _ButtonBottomCommand;
        public DelegateCommand ButtonBottomCommand =>
            _ButtonBottomCommand ?? (_ButtonBottomCommand = new DelegateCommand(ExcuteButtonBottomCommand));

        private void ExcuteButtonBottomCommand(object obj)
        {
            if (IsBottomOpen)
            {
                IsBottomOpen = false;
            }
            else
            {
                IsBottomOpen = true;
            }

        }
    }
}
