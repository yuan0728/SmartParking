using Microsoft.IdentityModel.Tokens;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;
using XH.SmartParking.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XH.SmartParking.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<MenuItemModel> _menus = new ObservableCollection<MenuItemModel>();

        public ObservableCollection<MenuItemModel> Menus
        {
            get { return _menus; }
            set { SetProperty<ObservableCollection<MenuItemModel>>(ref _menus, value); }
        }

        public DelegateCommand<object> OpenViewCommand { get; set; }
        private List<SysMenu> origMenus;

        private readonly IDialogService _dialogService;
        private readonly IMenuService _menuService;
        private readonly IRegionManager _regionManager;
        public MainViewModel(IDialogService dialogService, IMenuService menuService,IRegionManager regionManager)
        {
            _dialogService = dialogService;
            _menuService = menuService;
            _regionManager = regionManager;
            // 打开登录窗口
            OpenLoginWindow();

            // 加载菜单
            origMenus = menuService.GetMeunList().ToList();
            FillMenus(Menus, 0);

            // 打开窗口
            OpenViewCommand = new DelegateCommand<object>(DoOpenView);

        }

        // 打开窗口
        private void DoOpenView(object view)
        {
            // 如果双击的时候是父节点 关闭或者打开
            MenuItemModel menuItem = view as MenuItemModel;
            if (menuItem.Children != null && menuItem.Children.Count != 0)
            {
                menuItem.IsExpanded = !menuItem.IsExpanded;
            }
            else if (!string.IsNullOrEmpty(menuItem.TargetView))
            {
                _regionManager.RequestNavigate("MainRegion", menuItem.TargetView);
            }
        }

        // 打开登录窗口
        private void OpenLoginWindow()
        {
            _dialogService.ShowDialog("LoginView", result =>
            {
                if (result.Result != ButtonResult.OK)
                {
                    // 如果没有登录成功 直接退出
                    System.Environment.Exit(0);
                }

            });
        }

        // 填充菜单
        public void FillMenus(ObservableCollection<MenuItemModel> menus, int parent_id)
        {
            var sub = origMenus.Where(x => x.ParentId == parent_id).OrderBy(o => o.Index).ToList();
            if (sub.Count() > 0)
            {
                foreach (SysMenu item in sub)
                {
                    var menuItem = new MenuItemModel
                    {
                        MenuHeader = item.MenuHeader,
                        // 可以转换为十六进制字符表示
                        //MenuIcon = string.IsNullOrEmpty(item.MenuIcon) ? null : ((char)Convert.ToInt32(item.MenuIcon, 16)).ToString(),
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView
                    };

                    // item.MenuId 是 menuItem.Children 的父Id
                    FillMenus(menuItem.Children, item.MenuId);

                    menus.Add(menuItem);
                }
            }
        }
        
    }
}
