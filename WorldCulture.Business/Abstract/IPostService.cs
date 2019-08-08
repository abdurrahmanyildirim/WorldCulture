﻿using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetPostsByPlaceId(int placeId);
        Post GetPostById(int postId);
    }
}