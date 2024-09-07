using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;

namespace XH.SmartParking.IService
{
    public interface IRoleService : IBaseService
    {
        IEnumerable<SysRole> GetRoles(string key);
    }
}
