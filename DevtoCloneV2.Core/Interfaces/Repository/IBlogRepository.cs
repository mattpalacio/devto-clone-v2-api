using DevtoCloneV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Interfaces.Repository
{
    public interface IBlogRepository
    {
        public Task<IEnumerable<Blog>> GetAllBlogPosts();
        public Task<Blog?> GetBlogPostById(object id);
        public void CreateBlogPost(Blog blog);
        public void UpdateBlogPost(Blog blog);
        public void DeleteBlogPost(Blog blog);
        public Task SaveAsync();
    }
}
