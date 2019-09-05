using System.Collections.Generic;
using WorldCulture.Core.DataAccess;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Abstract
{
    public interface IAccountDal:IEntityRepository<Account>
    {
        List<Account> GetHasMostFollowerAccounts();
    }
}
