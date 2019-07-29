using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Core.DataAccess;
using WorldCulture.Core.DataAccess.EntityFramework;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
    }
}
