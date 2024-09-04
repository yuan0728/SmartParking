using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;

namespace XH.SmartParking.IService
{
    public interface IMenuService:IBaseService
    {
        IEnumerable<SysMenu> GetMeunList(string key = "");
    }
}
