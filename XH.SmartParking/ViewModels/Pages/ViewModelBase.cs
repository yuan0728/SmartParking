using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.ViewModels.Pages
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public string PageTitle { get; set; } = "页面标题";
        public bool IsCanClose { get; set; } = true;
        public DelegateCommand CloseCommand { get; set; }

        private readonly IRegionManager _regionManager;
        public ViewModelBase(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseCommand = new DelegateCommand(DoClose);
        }

        // 执行关闭逻辑
        private void DoClose()
        {
            var region = _regionManager.Regions["MainRegion"];
            // 删除当前类型ViewModel中的Model
            var view = region.Views.Where(x => x.GetType().Name == PageName).FirstOrDefault();
            if (view != null)
            {
                region.Remove(view);
            }
        }

        private string PageName { get; set; }

        // 获取到导航的路径
        public void OnNavigatedTo(NavigationContext navigationContext) => PageName = navigationContext.Uri.ToString();

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}
