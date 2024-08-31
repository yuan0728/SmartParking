using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; } // 双击这个节点的时候 打开的页面


        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty<bool>(ref _isExpanded, value); }
        }

        public ObservableCollection<MenuItemModel> Children { get; set; } = new ObservableCollection<MenuItemModel>();

    }
}
