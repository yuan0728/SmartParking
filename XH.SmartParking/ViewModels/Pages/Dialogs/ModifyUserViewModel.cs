using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.SmartParking.Base;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;
using XH.SmartParking.Service;

namespace XH.SmartParking.ViewModels.Pages.Dialogs
{
    public class ModifyUserViewModel : DialogViewModelBase, IDialogAware
    {

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<object>("model") as UserModel;
            if (model == null)
            {
                Title = "用户管理新增";
                UserInfo = new UserModel(_userService);
                UserInfo.Password = "123456"; // 默认密码
                UserInfo.UserIcon = "a01.jpg";
                UserInfo.UserName = "";
            }
            else
            {
                Title = "用户管理编辑";
                var u = _userService.Find<SysUser>(model.UserId);
                UserInfo = new UserModel();
                UserInfo.UserId = u.UserId;
                UserInfo.UserName = u.UserName;
                UserInfo.Phone = u.Phone;
                UserInfo.Age = u.Age;
                UserInfo.Password = u.Password;
                UserInfo.RealName = u.RealName;
                UserInfo.Address = u.Address;
                UserInfo.Email = u.Email;
                UserInfo.Gender = u.Gender;
                UserInfo.Status = u.Status;
                Man = UserInfo.Gender == 1;
                IsReadOnlyUserName = true;
            }
        }
        public UserModel UserInfo { get; set; } = new UserModel();


        private bool _man;

        public bool Man
        {
            get { return _man; }
            set
            {
                Woman = !value;
                SetProperty<bool>(ref _man, value);
            }
        }
        private bool _woman;

        public bool Woman
        {
            get { return _woman; }
            set { SetProperty<bool>(ref _woman, value); }
        }
        public bool IsReadOnlyUserName { get; set; }
        private readonly IUserService _userService;
        public ModifyUserViewModel(IUserService userService)
        {
            _userService = userService;
        }
        public override void DoSave()
        {

            if (UserInfo.HasErrors) { return; }

            try
            {
                if (Title.Equals("用户管理新增"))
                {
                    // UserID 的编码规则：
                    // 4位年份 XXXX
                    // 3位序号 XXX
                    int uid = DateTime.Now.Year * 1000;
                    int num = _userService.Set<SysUser>().Max(x => x.UserId) % uid;
                    uid += num + 1;
                    _userService.Insert(new SysUser
                    {
                        UserId = uid,
                        UserName = UserInfo.UserName,
                        RealName = UserInfo.RealName,
                        Password = UserInfo.Password,
                        Address = UserInfo.Address,
                        Age = UserInfo.Age,
                        UserIcon = UserInfo.UserIcon,
                        Phone = UserInfo.Phone,
                        Gender = Man ? 1 : 0,
                    });
                }
                else
                {
                    // 编辑
                    //var entity = _userService.Find<SysMenu>(MenuModel.MenuId);
                    //entity.MenuHeader = MenuModel.MenuHeader;
                    //entity.MenuType = MenuTypeList ? 1 : 0;
                    //entity.ParentId = MenuModel.ParentId;
                    //entity.TargetView = MenuModel.TargetView;
                    //entity.MenuIcon = MenuModel.MenuIcon;
                    //_userService.Update(entity);
                }
                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
