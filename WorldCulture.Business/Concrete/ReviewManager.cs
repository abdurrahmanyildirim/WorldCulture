using System.Collections.Generic;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class ReviewManager : IReviewService
    {
        private IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public void Add(Review review)
        {
            _reviewDal.Add(review);
        }

        public List<Review> GetReviewsByPost(int postId)
        {
            return _reviewDal.GetAll(x => x.PostID == postId);
        }
    }
}
