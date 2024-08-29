using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;

namespace XH.SmartParking.ViewModels
{
    // 包：Prism.Unity 8.1.97
    public class LoginViewModel : BindableBase, IDialogAware
    {

        #region 实现IDialogAware接口

        public string Title => "用户登录";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        #endregion


        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }



        private string _password = "";

        public string Password
        {
            get { return _password; }
            set { SetProperty<string>(ref _password, value); }
        }


        // 是否记住密码
        private bool _isRecord;

        public bool IsRecord
        {
            get { return _isRecord; }
            set { SetProperty<bool>(ref _isRecord, value); }
        }

        public DelegateCommand LoginCommand { get; set; }



        private readonly IUserService _userService;

        public LoginViewModel(IUserService userService)
        {
            LoginCommand = new DelegateCommand(DoLogin);
            _userService = userService;
        }

        private void DoLogin()
        {
            _userService.Login(UserName, Password);
        }
    }
}
