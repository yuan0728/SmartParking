using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XH.SmartParking.Base;
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


        private bool _isDropdownAvatar;

        public bool IsDropdownAvatar
        {
            get { return _isDropdownAvatar; }
            set { SetProperty<bool>(ref _isDropdownAvatar, value); }
        }



        public UserModel CurrentUser { get; set; } = new UserModel();// 当前用户的登录信息

        public DelegateCommand<object> OpenViewCommand { get; set; }
        public DelegateCommand<object> SetAvatarCommand { get; set; }
        public DelegateCommand ModifyPasswordCommand { get; set; }
        public DelegateCommand SwitchCommand { get; set; }
        private List<SysMenu> origMenus;
        private readonly IDialogService _dialogService;
        private readonly IMenuService _menuService;
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        public MainViewModel(
            IDialogService dialogService,
            IMenuService menuService,
            IRegionManager regionManager,
            IUserService userService,
            IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _menuService = menuService;
            _regionManager = regionManager;
            _userService = userService;
            // 打开登录窗口
            OpenLoginWindow();

            // 加载菜单
            LoadMenus();

            // 打开窗口
            OpenViewCommand = new DelegateCommand<object>(DoOpenView);
            SetAvatarCommand = new DelegateCommand<object>(DoSetAvatar);
            ModifyPasswordCommand = new DelegateCommand(DoModifyPassword);
            SwitchCommand = new DelegateCommand(DoSwitch);

            // 订阅刷新页面：
            eventAggregator.GetEvent<MenuRefreshMessage>().Subscribe(ReceiveLoadMenus);

        }

        // 设置头像
        private void DoSetAvatar(object obj)
        {
            try
            {
                string avatar = (string)obj;
                if (string.IsNullOrEmpty(avatar))
                {
                    // 打开选择文件窗口
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "图片格式|*.jpg;*.png;*.jpeg";
                    openFileDialog.CheckFileExists = true;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        avatar = openFileDialog.SafeFileName; // 文件名称 不是路径
                        // 复制到当前目录下
                        string target_path = Path.Combine(Environment.CurrentDirectory, "Avatarts", avatar);
                        if (!File.Exists(target_path))
                        {
                            File.Copy(openFileDialog.FileName, target_path);
                        }
                    }
                    else { return; }
                }
                // 保存
                var user = _userService.Find<SysUser>(CurrentUser.UserId);
                user.UserIcon = avatar;
                _userService.Update(user);
                CurrentUser.UserIcon = "pack://siteoforigin:,,,/Avatarts/" + avatar;
                IsDropdownAvatar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 切换用户
        private void DoSwitch()
        {
            Process.Start("XH.SmartParking.exe");
            Environment.Exit(0);
        }

        // 修改密码
        private void DoModifyPassword()
        {
            DialogParameters param = new DialogParameters();
            param.Add("user", CurrentUser);
            _dialogService.ShowDialog("ModifyPasswordView", param, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    // 如果修改完成 重新登录
                    // 提示下 是否现在重启
                    if (MessageBox.Show("是否立即重启？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        DoSwitch();
                    }
                }
            });
        }

        // 刷新菜单
        private void ReceiveLoadMenus()
        {
            LoadMenus();
        }

        public void LoadMenus()
        {
            Menus.Clear();
            origMenus = _menuService.GetMeunList().ToList();
            FillMenus(Menus, 0);
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
                else
                {
                    // 记录当前登录信息
                    var su = result.Parameters.GetValue<SysUser>("user");
                    CurrentUser.UserId = su.UserId;
                    CurrentUser.UserName = su.UserName;
                    CurrentUser.RealName = su.RealName;
                    CurrentUser.Password = su.Password;
                    CurrentUser.Age = su.Age;
                    CurrentUser.Gender = su.Gender;
                    CurrentUser.UserIcon = "pack://siteoforigin:,,,/Avatarts/" + su.UserIcon;
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
