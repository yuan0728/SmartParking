using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Regions;
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

namespace XH.SmartParking.ViewModels.Pages
{
    public class UserManagementViewModel : ViewModelBase
    {
        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();

        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        public UserManagementViewModel(IRegionManager regionManager, IUserService userService)
            : base(regionManager)
        {
            PageTitle = "系统用户";
            _regionManager = regionManager;
            _userService = userService;
            Refresh();


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
                    // 动态的访问资源、并且在当前bin\debug\文件夹内
                    UserIcon = "pack://siteoforigin:,,,/Avatarts/" + u.Avatar,
                    Address = u.Address,
                    Gender = u.Gender == 1 ? "男" : u.Gender == 0 ? "女" : "未知",
                });
            }
        }
        public override void DoDelete(object obj)
        {
            base.DoDelete(obj);
        }
        public override void DoModify(object obj)
        {
            base.DoModify(obj);
        }
    }
}
