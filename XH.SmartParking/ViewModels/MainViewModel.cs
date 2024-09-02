using Prism.Mvvm;
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

        private List<SysMenu> origMenus;

        private readonly IDialogService _dialogService;
        private readonly IMenuService _menuService;
        public MainViewModel(IDialogService dialogService, IMenuService menuService)
        {
            _dialogService = dialogService;
            _menuService = menuService;
            // 打开登录窗口
            OpenLoginWindow();

            // 加载菜单
            origMenus = menuService.GetMeunList().ToList();
            FillMenus(Menus, 0);
        }

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

        private void FillMenus(ObservableCollection<MenuItemModel> menus, int parent_id)
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
        private char? TryConvertToUnicodeChar(string hexCode)
        {
            if (string.IsNullOrEmpty(hexCode) || hexCode.Length != 4) // 假设是4位的十六进制数  
                return null;

            if (int.TryParse(hexCode, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int codePoint))
            {
                // 如果codePoint是一个有效的Unicode码点（通常小于0x110000，但这里只检查非负和非空）  
                if (codePoint >= 0)
                    return Convert.ToChar(codePoint);
            }

            return null; // 转换失败  
        }
    }
}
