using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class DespatchManager : IDespatchService
    {
        private IDespatchDal _despatchDal;

        public DespatchManager(IDespatchDal despatchDal)
        {
            _despatchDal = despatchDal;
        }
    }
}
