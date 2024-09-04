using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;

namespace XH.SmartParking.Service
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(DbContext context) : base(context) { }

        public IEnumerable<SysMenu> GetMeunList(string key = "")
        {
            return this.Query<SysMenu>(m => string.IsNullOrEmpty(key) ? true :
                (m.MenuHeader.Contains(key) || 
                m.TargetView.Contains(key) ||
                // 检查当前菜单项的子项中有没有符合条件的 Header 或者 TargetView 关键词
                Context.Set<SysMenu>().Where(sm => sm.ParentId == m.MenuId && 
                (sm.MenuHeader.Contains(key) || 
                sm.TargetView.Contains(key))).Count() > 0));
        }
    }
}
