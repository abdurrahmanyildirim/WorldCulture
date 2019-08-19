using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class RelationManager : IRelationService
    {
        private IRelationDal _relationDal;

        public RelationManager(IRelationDal relationDal)
        {
            _relationDal = relationDal;
        }

        public bool isFollower(int currentAccountId,int otherAccountId)
        {
            return _relationDal.Get(x => x.FromAccountID == currentAccountId && x.ToAccountID == otherAccountId) == null ? false : true;
        }

        public void Delete(Relation relation)
        {
            _relationDal.Delete(relation);
        }

        public void Add(Relation relation)
        {
            _relationDal.Add(relation);
        }

        public Relation GetRelation(int fromId,int toId)
        {
            return _relationDal.Get(x => x.FromAccountID == fromId && x.ToAccountID == toId);
        }
    }
}
