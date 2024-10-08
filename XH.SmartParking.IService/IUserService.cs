﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Entities;

namespace XH.SmartParking.IService
{
    public interface IUserService : IBaseService
    {
        SysUser Login(string username, string password);
        bool CheckUserName(string userName);
        IEnumerable<SysUser> GetUsers(string key);
    }
}
