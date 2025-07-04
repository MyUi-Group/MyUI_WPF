using MyUiDemo.Help;
using MyUiDemo.Models;
using MyUiDemo.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyUiDemo.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private MenuModel _SelectedItem;
        public MenuModel SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        private List<MenuModel> _MenuList;
        public List<MenuModel> MenuList
        {
            get { return _MenuList; }
            set { SetProperty(ref _MenuList, value); }
        }
        private object _View;
        public object View
        {
            get { return _View; }
            set { SetProperty(ref _View, value); }
        }
        private DelegateCommand _GoPageCommand;
        public DelegateCommand GoPageCommand =>
            _GoPageCommand ?? (_GoPageCommand = new DelegateCommand(ExecuteGoPageCommand));

       
        public MainWindowViewModel() 
        {
            MenuList = GetMenus();
            SelectedItem = MenuList.FirstOrDefault();
            ExecuteGoPageCommand(SelectedItem.KeyType);
        
        }

        List<MenuModel> GetMenus()
        {
            var list = new List<MenuModel>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var data = assembly.DefinedTypes.Where(o => o.FullName.Contains("MyUiDemo.Views"));

            foreach (var type in data)
            {
                if (type.Name.Contains("<>c")) 
                {
                    continue;
                };
                var aliasAttr = type.GetCustomAttribute<PageAliasAttribute>();
                var menu = new MenuModel { Name = aliasAttr.Alias,Index=aliasAttr.Index, KeyType = assembly.CreateInstance(type.FullName).GetType() };
                list.Add(menu);
            }
            list= list.OrderBy(p=>p.Index).ToList();
            return list;
        }

        void ExecuteGoPageCommand(object data) => View = Activator.CreateInstance(data as Type);
    }
}
