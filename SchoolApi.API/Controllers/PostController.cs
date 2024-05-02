using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS.Post;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.ServiceDTOS.PostServiceDTOs;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchPost([FromQuery] string searchTerm, [FromQuery] int page, [FromQuery]int pageSize)
        {
            var posts = await _postService.SearchPost(
                new BaseSearchServiceRequest(searchTerm,page,pageSize));
            return Ok(posts);
        }
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostDetail(string postId)
        {
            Post? post = await _postService.GetPostDetail(postId);
            return Ok(post);
        }
        [HttpGet("multiple")]
        public async Task<IActionResult> GetMultiplePosts([FromQuery] int page, [FromQuery] int pageSize)
        {
            var posts = await _postService.GetMultiplePosts(
                new BaseGetMultipleServiceRequest(page,pageSize));
            return Ok(posts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(PostCreateRequest request)
        {
            var serviceRequest = _mapper.Map<PostCreateServiceRequest>(request);
            var post = await _postService.CreateSinglePost(serviceRequest);
            return Ok(post);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePost(PostUpdateRequest request)
        {
            var serviceRequest = _mapper.Map<PostUpdateServiceRequest>(request);
            Post? post = await _postService.UpdatePost(serviceRequest);
            return post==null?BadRequest():Ok(post) ;
        }
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(string postId)
        {
            var isDeleted = await _postService.DeleteSinglePost(postId);
            return isDeleted ? Ok() : NotFound("not found post");
        }
        [HttpDelete("multiple")]
        public async Task<IActionResult> DeleteMultiplePosts(IEnumerable<string> postIds)
        {
            var isDeleted = await _postService.DeleteMultiplePosts(postIds);
            return isDeleted ? Ok() : NotFound("not found post");
        }
    }
}
