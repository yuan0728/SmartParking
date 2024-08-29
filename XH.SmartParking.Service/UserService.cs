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
    public class UserService : BaseService, IUserService
    {
        public UserService(DbContext context) : base(context)
        {
        }

        public SysUser Login(string username, string password)
        {
            return this.Query<SysUser>(u => u.UserName == username && u.Password == password).ToList().FirstOrDefault();
        }
    }
}
