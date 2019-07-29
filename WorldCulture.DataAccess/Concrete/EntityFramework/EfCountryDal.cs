using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Core.DataAccess.EntityFramework;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.DataAccess.Concrete.EntityFramework.Context;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework
{
    public class EfCountryDal : EfEntityRepository<EfContext, Country>,ICountryDal
    {
    }
}
