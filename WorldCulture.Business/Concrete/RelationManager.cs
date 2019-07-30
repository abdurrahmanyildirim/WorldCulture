using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class RelationManager : IRelationService
    {
        private IRelationDal _relationDal;

        public RelationManager(IRelationDal relationDal)
        {
            _relationDal = relationDal;
        }
    }
}
