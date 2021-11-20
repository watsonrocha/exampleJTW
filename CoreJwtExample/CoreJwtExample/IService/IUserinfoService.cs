using CoreJwtExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJwtExample.IService
{
    public interface IUserinfoService
    {
        UserInfo Authenticate(string username, string password);
    }
}