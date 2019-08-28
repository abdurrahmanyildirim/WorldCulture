using System;
using System.Collections.Generic;
using System.Linq;
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

        public string GetFollowersCount(int accountId)
        {
            return _relationDal.GetAll(x => x.ToAccountID == accountId).Count.ToString();
        }

        public List<int> GetFollowerAccountsId(int accountId)
        {
            List<int> accountsId = new List<int>();
            List<Relation> followerAccounts = _relationDal.GetAll(x => x.ToAccountID == accountId);

            foreach (var item in followerAccounts)
            {
                accountsId.Add(item.FromAccountID);
            }
            return accountsId;
        }

        public string GetFollowingsCount(int accountId)
        {
            return _relationDal.GetAll(x => x.FromAccountID == accountId).Count.ToString();
        }

        public List<int> GetFollowingAccountsId(int accountId)
        {
            List<int> accountsId = new List<int>();
            List<Relation> followingAccounts= _relationDal.GetAll(x => x.FromAccountID == accountId);

            foreach (var item in followingAccounts)
            {
                accountsId.Add((int)item.ToAccountID);
            }
            return accountsId;
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
