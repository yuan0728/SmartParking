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
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(DbContext context) : base(context)
        {
        }

        public IEnumerable<SysRole> GetRoles(string key)
        {
            return Query<SysRole>(m => 
                string.IsNullOrEmpty(key) || 
                m.RoleDesc.Contains(key) ||
                m.RoleName.Contains(key));
        }
    }
}
