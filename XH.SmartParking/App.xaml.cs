using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;
using XH.SmartParking.Base;
using XH.SmartParking.IService;
using XH.SmartParking.ORM;
using XH.SmartParking.Service;
using XH.SmartParking.Views;

namespace XH.SmartParking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            // 主窗体
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册弹窗父类
            containerRegistry.RegisterDialogWindow<DialogWindowEX>();
            // 注册弹窗
            containerRegistry.RegisterDialog<LoginView>();

            // 注册相关的服务
            containerRegistry.Register<DbContext, XHDbContext>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IMenuService, MenuService>();
        }
    }
}
