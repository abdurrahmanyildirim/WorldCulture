using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Api.Dtos;
using WorldCulture.Api.Helpers;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IRelationService _relationService;
        private readonly IReviewService _reviewService;
        private readonly IFamousPlaceService _famousPlaceService;
        private readonly ICloudinaryConfiguration _cloudinaryConfiguration;

        public PostsController(IPostService postService,
            IMapper mapper,
            IRelationService relationService,
            IReviewService reviewService,
            IFamousPlaceService famousPlaceService,
            ICloudinaryConfiguration cloudinaryConfiguration)
        {
            _postService = postService;
            _mapper = mapper;
            _relationService = relationService;
            _reviewService = reviewService;
            _famousPlaceService = famousPlaceService;
            _cloudinaryConfiguration = cloudinaryConfiguration;
        }

        [HttpGet]
        [Route("api/posts/{id}")]
        public IActionResult GetPostsByPlaceID(int id)
        {
            var posts = _mapper.Map<List<PostForCardDto>>(_postService.GetPostsByPlaceId(id).OrderByDescending(x => int.Parse(x.CountOfView)));
            return Ok(posts);
        }

        [HttpGet]
        [Route("api/post/{id}")]
        public IActionResult GetPostByID(int id)
        {
            var post = _postService.GetPostById(id);
            post.CountOfView = (Convert.ToInt32(post.CountOfView) + 1).ToString();
            _postService.Update(post);
            return Ok(post);
        }

        [HttpGet]
        [Route("api/postsByAccount/{id}")]
        public IActionResult GetPostsByAccountID(int id)
        {
            var posts = _mapper.Map<List<PostForCardDto>>(_postService.GetPostsByAccountID(id));
            return Ok(posts);
        }

        [HttpPost]
        [Authorize]
        [Route("api/addReview")]
        public IActionResult AddReview([FromBody]Review review)
        {
            _reviewService.Add(review);
            List<Review> reviews = _reviewService.GetReviewsByPost(review.PostID);
            Post post = _postService.GetPostById(review.PostID);
            int rate = 0;
            foreach (var item in reviews)
            {
                rate = rate + item.Rate;
            }
            rate += post.Rate;
            rate = rate / (reviews.Count + 1);
            post.Rate = Convert.ToByte(rate);
            _postService.Update(post);
            return Ok(reviews);
        }

        [HttpGet]
        [Route("api/reviews/{id}")]
        public IActionResult GetReviews(int id)
        {
            return Ok(_reviewService.GetReviewsByPost(id).OrderByDescending(x => x.Rate));
        }

        [HttpGet]
        [Authorize]
        [Route("api/followingAccountPosts")]
        public IActionResult GetPostsByFollowingAccounts()
        {
            try
            {
                var currentAccountId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                List<int> followingAccountsId = _relationService.GetFollowingAccountsId(currentAccountId);
                List<PostForCardDto> posts = _mapper.Map<List<PostForCardDto>>(_postService.GetPostsByFollowingAccounts(followingAccountsId));
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/post/createPost")]
        public IActionResult CreatePost([FromBody]PostForCreationDto postForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentId != postForCreation.AccountID)
            {
                return Unauthorized();
            }

            Post post = _mapper.Map<Post>(postForCreation);
            post.CountOfView = "1";
            post.Rate = 0;

            _postService.Add(post);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("api/post/uploadPhoto")]
        public IActionResult UploadPhoto([FromForm]PhotoForUploadDto photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı işlem tespit edildi.");
            }

            if (int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == 0)
            {
                return Unauthorized();
            }

            if (photo.File == null)
            {
                return BadRequest("Gönderilen dosya hatalı");
            }

            var file = photo.File;
            CloudinaryForReturnDto cloudinaryForReturn = _cloudinaryConfiguration.UploadImage(file);
            return Ok(new PhotoForReturnDto
            {
                PostPhotoPath = cloudinaryForReturn.Url,
                PublicId = cloudinaryForReturn.PublicId
            });
        }
        //
        [HttpGet]
        [Route("api/post/most-view-posts")]
        public IActionResult GetMostViewPosts()
        {
            var mostViewPosts = _mapper.Map<List<PostForCardDto>>(_postService.GetMostViewPosts());
            return Ok(mostViewPosts);
        }

        [HttpGet]
        [Route("api/post/random-posts")]
        public IActionResult GetRandomPosts()
        {
            List<PostForCardDto> posts = _mapper.Map<List<PostForCardDto>>(_postService.GetRandomPosts());
            return Ok(posts);
        }
    }
}