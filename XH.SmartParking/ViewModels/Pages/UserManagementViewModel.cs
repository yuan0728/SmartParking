using Prism.Commands;
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
    public class UserManagementViewModel:ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        public UserManagementViewModel(IRegionManager regionManager)
            :base(regionManager)
        {
            PageTitle = "系统用户";
            _regionManager = regionManager;

        }
    }
}
