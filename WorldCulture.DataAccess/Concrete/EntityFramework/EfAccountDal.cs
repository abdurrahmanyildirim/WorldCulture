using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldCulture.Core.DataAccess.EntityFramework;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.DataAccess.Concrete.EntityFramework.Context;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework
{
    public class EfAccountDal : EfEntityRepository<EfContext, Account>,IAccountDal
    {
        public List<Account> GetHasMostFollowerAccounts()
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<Account> accounts = (from a in context.Accounts
                                                orderby a.ToAccounts.Count descending
                                                select a).Take(10);
                return accounts.ToList();
            }
        }
    }
}
