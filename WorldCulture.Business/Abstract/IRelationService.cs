using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IRelationService
    {
        bool isFollower(int currentAccountId, int otherAccountId);
        Relation GetRelation(int fromId, int toId);
        void Delete(Relation relation);
        void Add(Relation relation);
        List<int> GetFollowingAccountsId(int accountId);
    }
}