using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
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


        // 记住密码的本地文件
        private readonly string userPath = "userTemp.txt";

        private string _errorInfo;

        public string ErrorInfo
        {
            get { return _errorInfo; }
            set { SetProperty<string>(ref _errorInfo, value); }
        }



        private int _blurValue = 0;

        public int BlurValue
        {
            get { return _blurValue; }
            set { SetProperty<int>(ref _blurValue, value); }
        }

        private bool _isShowLoading;

        public bool IsShowLoading
        {
            get { return _isShowLoading; }
            set { SetProperty<bool>(ref _isShowLoading, value); }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }

        private string _password;

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
            // 读取本地的密码
            if(File.Exists(userPath))
            {
                string info = File.ReadAllText(userPath);
                UserName = Regex.Split(Regex.Split(info, "账号：")[1], "密码：")[0].Trim();
                Password = Regex.Split(Regex.Split(info, "账号：")[1], "密码：")[1].Trim();
            }

            LoginCommand = new DelegateCommand(DoLogin);
            _userService = userService;
        }

        private void DoLogin()
        {
            ShowLoading(true);
            ErrorInfo = "";

            Task.Run(async () =>
            {
                //await Task.Delay(2000);
                try
                {
                    var user = _userService.Login(UserName, Password);
                    if (user == null)
                    {
                        throw new Exception("用户名或者密码错误");
                    }
                    // 根据选项进行记录 密码
                    if (IsRecord)
                    {
                        string info = $"账号：{UserName} 密码：{Password}";
                        File.WriteAllText(userPath, info);
                    }
                    // 关闭登录窗口 进入主窗口
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        RequestClose.Invoke(new DialogResult(ButtonResult.OK));
                    });
                }
                catch (Exception ex)
                {
                    ErrorInfo = ex.Message;
                }
                finally
                {
                    ShowLoading(false);
                }
            });
        }

        // 打开 loading 和 虚幻
        private void ShowLoading(bool bl = true)
        {
            if (bl)
            {
                IsShowLoading = true;
                BlurValue = 5;
            }
            else
            {
                IsShowLoading = false;
                BlurValue = 0;
            }
        }
    }
}
