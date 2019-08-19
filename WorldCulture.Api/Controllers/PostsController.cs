using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Api.Dtos;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/posts/{id}")]
        public IActionResult GetPostsByPlaceID(int id)
        {
            var posts = _mapper.Map<List<PostForCardDto>>(_postService.GetPostsByPlaceId(id));
            return Ok(posts);
        }

        [HttpGet]
        [Route("api/post/{id}")]
        public IActionResult GetPostByID(int id)
        {
            var posts = _postService.GetPostById(id);
            return Ok(posts);
        }

        [HttpGet]
        [Route("api/postsByAccount/{id}")]
        public IActionResult GetPostsByAccountID(int id)
        {
            var posts = _mapper.Map<List<PostForCardDto>>(_postService.GetPostsByAccountID(id));
            return Ok(posts);
        }

        [HttpPost]
        [Route("api/post/add")]
        public IActionResult CreatePost([FromBody]Post post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Hatalı işlem tespit edildi.");
                }

                Post addedPost = new Post
                {
                    AccountID = post.AccountID,
                    CreatedDate = DateTime.Now,
                    CountOfView = "0",
                    Description = post.Description,
                    FamousPlaceID = post.FamousPlaceID,
                    PostPhotoPath = post.PostPhotoPath,
                    Rate = 0,
                    Title = post.Title
                };

                _postService.Add(addedPost);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}