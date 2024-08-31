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

        public IEnumerable<SysMenu> GetMeunList()
        {
            return this.Query<SysMenu>(m => true);
        }
    }
}
