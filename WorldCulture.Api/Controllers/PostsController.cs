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
    }
}