using AutoMapper;
using DevtoCloneV2.Api.DTOs.Blog;
using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevtoCloneV2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;

        public BlogController(IMapper mapper, IBlogService blogService)
        {
            _mapper = mapper;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await _blogService.GetAllBlogPosts();
            var blogPostsDto = _mapper.Map<IEnumerable<BlogResponseDto>>(blogPosts);
            return Ok(blogPostsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            var blogPost = await _blogService.GetBlogPostById(id);
            var blogPostDto = _mapper.Map<BlogResponseDto>(blogPost);
            return Ok(blogPostDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogRequestDto newBlogPostDto)
        {
            var newBlogPost = _mapper.Map<Blog>(newBlogPostDto);
            await _blogService.CreateBlogPost(newBlogPost);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(int id, [FromBody] UpdateBlogRequestDto updatedBlogPostDto)
        {
            var updatedBlogPost = _mapper.Map<Blog>(updatedBlogPostDto);
            await _blogService.UpdateBlogPost(id, updatedBlogPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            await _blogService.DeleteBlogPost(id);
            return NoContent();
        }
    }
}
