using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetPostsByPlaceId(int placeId);
        Post GetPostById(int postId);
        void Add(Post post);
        void Update(Post post);
        List<Post> GetPostsByAccountID(int accountId);
        List<Post> GetPostsByFollowingAccounts(List<int> accountsId);
    }
}