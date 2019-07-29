using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class RelationManger : IRelationService
    {
        private IRelationDal _relationDal;

        public RelationManger(IRelationDal relationDal)
        {
            _relationDal = relationDal;
        }
    }
}
