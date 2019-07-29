using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Role
    {
        public Role()
        {
            Account = new List<Account>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public virtual List<Account> Account { get; set; }
    }
}
