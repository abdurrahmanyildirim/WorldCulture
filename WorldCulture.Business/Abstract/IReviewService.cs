using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IReviewService
    {
        void Add(Review review);
        List<Review> GetReviewsByPost(int postId);
    }
}