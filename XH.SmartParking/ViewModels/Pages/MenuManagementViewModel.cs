﻿using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;
using XH.SmartParking.Service;

namespace XH.SmartParking.ViewModels.Pages
{
    public class MenuManagementViewModel : ViewModelBase
    {

        private ObservableCollection<MenuItemModel> _menus = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MenuItemModel> Menus
        {
            get { return _menus; }
            set { SetProperty<ObservableCollection<MenuItemModel>>(ref _menus, value); }
        }

        private string _searchKey;

        public string SearchKey
        {
            get { return _searchKey; }
            set { SetProperty<string>(ref _searchKey, value); }
        }

        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand<object> ModifyCommand { get; set; }
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;
        private readonly IDialogService _dialogService;

        private List<SysMenu> origMenus;
        public MenuManagementViewModel(IRegionManager regionManager, IMenuService menuService, IDialogService dialogService)
            : base(regionManager)
        {
            PageTitle = "菜单管理";
            _regionManager = regionManager;
            _menuService = menuService;
            _dialogService = dialogService;
            RefreshCommand = new DelegateCommand(Refresh);
            ModifyCommand = new DelegateCommand<object>(DoModify);

            Refresh();
        }

        // 新增和编辑
        private void DoModify(object obj)
        {
            DialogParameters ps = new DialogParameters();
            ps.Add("model", obj);
            _dialogService.ShowDialog("ModifyMenuView", ps, result =>
            {
                // 返回当前页面 如果OK 刷新 否则不管
                if (result.Result == ButtonResult.OK)
                    this.Refresh();
            });
        }


        // 刷新
        private void Refresh()
        {
            Menus.Clear();
            // 加载菜单
            origMenus = _menuService.GetMeunList(SearchKey).ToList();

            FillMenus(Menus, 0);
        }

        // 填充菜单
        private void FillMenus(ObservableCollection<MenuItemModel> menus, int parent_id)
        {
            var sub = origMenus.Where(x => x.ParentId == parent_id).OrderBy(o => o.Index).ToList();
            if (sub.Count() > 0)
            {
                foreach (SysMenu item in sub)
                {
                    var menuItem = new MenuItemModel
                    {
                        MenuId = item.MenuId,
                        MenuType = item.MenuType,
                        MenuHeader = item.MenuHeader,
                        // 可以转换为十六进制字符表示
                        //MenuIcon = string.IsNullOrEmpty(item.MenuIcon) ? null : ((char)Convert.ToInt32(item.MenuIcon, 16)).ToString(),
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView,
                        ParentId = parent_id,
                        IsExpanded = true
                    };

                    // item.MenuId 是 menuItem.Children 的父Id
                    FillMenus(menuItem.Children, item.MenuId);

                    menus.Add(menuItem);
                }
                if (parent_id > 0)
                {
                    menus[menus.Count - 1].IsLastChild = true;
                }
            }
        }


        #region 第一版关闭逻辑

        //// 执行关闭逻辑
        //private void DoClose()
        //{
        //    var region = _regionManager.Regions["MainRegion"];
        //    // 删除当前类型ViewModel中的Model
        //    var view = region.Views.Where(x => x.GetType().Name == this.GetType().Name.Substring(0, this.GetType().Name.Length - 5)).FirstOrDefault();
        //    if (view != null)
        //    {
        //        region.Remove(view);
        //    }
        //}

        #endregion
    }
}