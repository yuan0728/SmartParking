using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.ViewModels
{
    public class MainViewModel
    {
        private readonly IDialogService _dialogService;
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            // 打开登录窗口
            OpenLoginWindow();

            // 当前窗口要做的事
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
    }
}
