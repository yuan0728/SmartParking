using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.IService
{
    public interface IUserService : IBaseService
    {
        void Login(string username, string password);
    }
}
