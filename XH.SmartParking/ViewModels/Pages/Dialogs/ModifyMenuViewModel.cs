using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;

namespace XH.SmartParking.ViewModels.Pages.Dialogs
{
    public class ModifyMenuViewModel : DialogViewModelBase
    {
        private bool _menuTypeList;

        public bool MenuTypeList
        {
            get { return _menuTypeList; }
            set
            {
                SetProperty<bool>(ref _menuTypeList, value);
                MenuTypeView = !value;
            }
        }
        private bool _menuTypeView;

        public bool MenuTypeView
        {
            get { return _menuTypeView; }
            set
            {
                SetProperty<bool>(ref _menuTypeView, value);
            }
        }
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var model = parameters.GetValue<object>("model") as MenuItemModel;
            if (model == null)
            {
                // 新增
                Title = "菜单管理新增";
                MenuModel.ParentId = 0; // 默认新增一级菜单
                MenuModel.MenuType = 1; // 默认新增一个集合类型的节点
                MenuTypeList = true;
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
                MenuTypeList = MenuModel.MenuType == 1 ? true : false;
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

        public override void DoSave()
        {
            try
            {
                if (Title.Equals("菜单管理新增"))
                {
                    TimeSpan ts = DateTime.UtcNow - new DateTime(2024, 1, 1, 0, 0, 0, 0);
                    int key = Convert.ToInt32(ts.TotalSeconds);
                    _menuService.Insert(new SysMenu
                    {
                        MenuId = (int)key,
                        MenuHeader = MenuModel.MenuHeader,
                        MenuType = MenuTypeList? 1 : 0 ,
                        ParentId = MenuModel.ParentId,
                        TargetView = MenuModel.TargetView,
                        MenuIcon = MenuModel.MenuIcon,
                        State = 1,
                    });
                }
                else
                {
                    // 编辑
                    var entity = _menuService.Find<SysMenu>(MenuModel.MenuId);
                    entity.MenuHeader = MenuModel.MenuHeader;
                    entity.MenuType = MenuTypeList ? 1 : 0;
                    entity.ParentId = MenuModel.ParentId;
                    entity.TargetView = MenuModel.TargetView;
                    entity.MenuIcon = MenuModel.MenuIcon;
                    _menuService.Update(entity);
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
