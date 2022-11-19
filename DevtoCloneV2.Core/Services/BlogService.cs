using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Exceptions;
using DevtoCloneV2.Core.Interfaces.Repository;
using DevtoCloneV2.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository) => _blogRepository = blogRepository;

        public async Task<IEnumerable<Blog>> GetAllBlogPosts()
        {
            return await _blogRepository.GetAllBlogPosts();
        }

        public async Task<Blog> GetBlogPostById(int id)
        {
            return await _blogRepository.GetBlogPostById(id)
                ?? throw new NotFoundCoreException($"Blog post with id {id} not found.");
        }

        public async Task CreateBlogPost(Blog blog)
        {
            _blogRepository.CreateBlogPost(blog);
            await _blogRepository.SaveAsync();
        }

        public async Task UpdateBlogPost(int id, Blog blog)
        {
            var existingBlogPost = await GetBlogPostById(id);
            existingBlogPost.Title = blog.Title;
            existingBlogPost.Content = blog.Content;

            _blogRepository.UpdateBlogPost(existingBlogPost);
            await _blogRepository.SaveAsync();
        }

        public async Task DeleteBlogPost(int id)
        {
            var existingBlogPost = await GetBlogPostById(id);
            _blogRepository.DeleteBlogPost(existingBlogPost);
            await _blogRepository.SaveAsync();
        }
    }
}
