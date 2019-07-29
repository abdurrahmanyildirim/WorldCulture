using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class ReviewManager : IReviewService
    {
        private IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }
    }
}
