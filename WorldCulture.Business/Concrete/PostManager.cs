using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> GetPostsByPlaceId(int placeId)
        {
            return _postDal.GetAll(x => x.FamousPlaceID == placeId);
        }

        public Post GetPostById(int postId)
        {
            return _postDal.Get(x => x.PostID == postId);
        }
    }
}
