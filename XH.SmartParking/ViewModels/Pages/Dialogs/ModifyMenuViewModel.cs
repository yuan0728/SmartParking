using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;

namespace XH.SmartParking.ViewModels.Pages.Dialogs
{
    public class ModifyMenuViewModel : IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<object>("model") as MenuItemModel;
            if (model == null)
            {
                // 新增
                Title = "菜单管理新增";
            }
            else
            {
                // 编辑
                Title = "菜单管理编辑";
                // 1.根据 menuid 从数据中获取数据更新完成之后 提交数据库
                var sm = _menuService.Find<SysMenu>(model.MenuId);
                MenuModel.MenuId = sm.MenuId;
                MenuModel.MenuHeader = sm.MenuHeader;
                MenuModel.ParentId = sm.ParentId;
                MenuModel.TargetView = sm.TargetView;
                MenuModel.MenuIcon = sm.MenuIcon;
                MenuModel.MenuType = sm.MenuType;
            }
            // 获取所有不带视图的菜单
            var pmenus = _menuService.Query<SysMenu>(m => m.MenuType == 1).ToList();
            pmenus.ForEach(p =>
            {
                ParentNodes.Add(new MenuItemModel()
                {
                    MenuId = p.MenuId,
                    MenuHeader = p.MenuHeader,
                });
            });
        }
        public MenuItemModel MenuModel { get; set; } = new MenuItemModel();
        public int SelectedParentId { get; set; }
        public List<MenuItemModel> ParentNodes { get; set; } = new List<MenuItemModel>() 
        {
            new MenuItemModel() { MenuHeader = "ROOT",MenuId = 0}
        };

        private readonly IMenuService _menuService;
        public ModifyMenuViewModel(IMenuService menuService)
        {
            _menuService = menuService;
        }
    }
}
