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

        public bool CheckUserName(string userName)
        {
            return false;
        }

        public IEnumerable<SysUser> GetUsers(string key)
        {
            return Query<SysUser>(u => string.IsNullOrEmpty(key) ? true : 
                                  u.UserId.ToString().Contains(key) ||
                                  u.RealName.ToString().Contains(key) ||
                                  u.Address.ToString().Contains(key) ||
                                  u.UserName.Contains(key));
        }

        public SysUser Login(string username, string password)
        {
            return this.Query<SysUser>(u => u.UserName == username && u.Password == password).ToList().FirstOrDefault();
        }
    }
}
