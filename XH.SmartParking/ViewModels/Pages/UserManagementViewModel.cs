using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;
using XH.SmartParking.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XH.SmartParking.ViewModels.Pages
{
    public class UserManagementViewModel : ViewModelBase
    {
        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
        public DelegateCommand<object> SelectRoleCommand { get; set; }
        public DelegateCommand<object> ResetPasswordCommand { get; set; }
        public DelegateCommand<object> LockUserCommand { get; set; }
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;
        public UserManagementViewModel(IRegionManager regionManager, IUserService userService,IDialogService dialogService)
            : base(regionManager)
        {
            PageTitle = "系统用户";
            _regionManager = regionManager;
            _userService = userService;
            _dialogService = dialogService;
            Refresh();

            SelectRoleCommand = new DelegateCommand<object>(DoSelectRole);
            ResetPasswordCommand = new DelegateCommand<object>(DoResetPassword);
            LockUserCommand = new DelegateCommand<object>(DoLockUser);
        }

        // 锁定/解开角色
        private void DoLockUser(object obj)
        {
            var model = obj as UserModel;
        }

        // 重置密码
        private void DoResetPassword(object obj)
        {
            var model = obj as UserModel;
        }

        // 选择角色
        private void DoSelectRole(object obj)
        {
            var model = obj as UserModel;
        }

        public override void Refresh()
        {
            Users.Clear();
            var users = _userService.GetUsers(SearchKey).ToList();
            int index = 1;
            foreach (var u in users)
            {
                Users.Add(new UserModel
                {
                    Index = index++,
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Age = u.Age,
                    Password = u.Password,
                    RealName = u.RealName,
                    // pack://siteoforigin:,,,：动态的访问资源、并且在当前bin\debug\文件夹内
                    UserIcon = "pack://siteoforigin:,,,/Avatarts/" + u.UserIcon,
                    Address = u.Address,
                    Email = u.Email,
                    Gender = u.Gender,
                    Status = u.Status,
                    LockButtonText = u.Status == 1 ? "冻结" : u.Status == 0 ? "启用" : "",
                });
            }
        }
        public override void DoDelete(object obj)
        {
            
        }
        public override void DoModify(object obj)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", obj);
            _dialogService.ShowDialog("ModifyUserView", ps, result =>
            {
                // 返回当前页面 如果OK 刷新 否则不管
                if (result.Result == ButtonResult.OK)
                {
                    this.Refresh();
                }
            });
        }
    }
}
