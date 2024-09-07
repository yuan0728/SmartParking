using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.IService;
using XH.SmartParking.Models;
using XH.SmartParking.Service;

namespace XH.SmartParking.ViewModels.Pages
{
    public class RoleViewModel : ViewModelBase
    {
        public ObservableCollection<RoleModel> RoleList { get; set; } = new ObservableCollection<RoleModel>();
        private readonly IRoleService _roleService;
        public RoleViewModel(IRegionManager regionManager, IRoleService roleService)
            : base(regionManager)
        {
            _roleService = roleService;

            this.PageTitle = "角色权限组";

            Refresh();
        }

        public override void Refresh()
        {
            RoleList.Clear();
            var rs = _roleService.GetRoles(SearchKey);
            foreach (var r in rs)
            {
                RoleList.Add(new RoleModel
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                    RoleDesc = r.RoleDesc
                });
            }

        }
        public override void DoModify(object obj)
        {
            base.DoModify(obj);
        }
        public override void DoDelete(object obj)
        {
            base.DoDelete(obj);
        }
    }
}
