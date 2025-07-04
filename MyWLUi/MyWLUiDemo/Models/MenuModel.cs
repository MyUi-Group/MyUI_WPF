using MyWLUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.Models
{
    internal class MenuModel : BindableBase
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        public int Index { set; get; }

        private Type _KeyType;
        public Type KeyType
        {
            get { return _KeyType; }
            set { SetProperty(ref _KeyType, value); }
        }
    }
}
