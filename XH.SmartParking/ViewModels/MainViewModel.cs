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
        public MainViewModel(IDialogService dialogService)
        {
            // 打开登录窗口
            dialogService.ShowDialog("LoginView", result =>
            {
                if(result.Result != ButtonResult.OK)
                {
                    // 如果没有登录成功 直接退出
                    System.Environment.Exit(0);
                }
            });

            // 当前窗口要做的事
        }

    }
}
