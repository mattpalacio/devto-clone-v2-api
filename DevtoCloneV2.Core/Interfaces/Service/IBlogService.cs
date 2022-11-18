using DevtoCloneV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Interfaces.Service
{
    public interface IBlogService
    {
        public Task<IEnumerable<Blog>> GetAllBlogPosts();
        public Task<Blog> GetBlogPostById(int id);
        public Task CreateBlogPost(Blog blog);
        public Task UpdateBlogPost(int id, Blog blog);
        public Task DeleteBlogPost(int id);
    }
}
