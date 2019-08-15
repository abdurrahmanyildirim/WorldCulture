using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public string GetRole(int roleId)
        {
            return _roleDal.Get(x => x.RoleID == roleId).RoleName;
        }
    }
}
