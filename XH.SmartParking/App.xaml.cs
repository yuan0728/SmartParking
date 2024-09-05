using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;
using XH.SmartParking.Base;
using XH.SmartParking.IService;
using XH.SmartParking.ORM;
using XH.SmartParking.Service;
using XH.SmartParking.Views;
using XH.SmartParking.Views.Pages;
using XH.SmartParking.Views.Pages.Dialogs;

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

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            // 打开初始页面
            //Container.Resolve<IRegionManager>().RegisterViewWithRegion("MainRegion", "DashboardView");
            Container.Resolve<IRegionManager>().RequestNavigate("MainRegion", "DashboardView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册弹窗父类
            containerRegistry.RegisterDialogWindow<DialogWindowEX>();
            // 注册弹窗
            containerRegistry.RegisterDialog<LoginView>();
            containerRegistry.RegisterDialog<ModifyMenuView>();

            // 注册相关的服务
            containerRegistry.RegisterSingleton<DbContext, XHDbContext>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IMenuService, MenuService>();

            // 注册导航
            containerRegistry.RegisterForNavigation<DashboardView>();
            containerRegistry.RegisterForNavigation<MenuManagementView>();
            containerRegistry.RegisterForNavigation<UserManagementView>();
        }
    }
}
