using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppContext _context;

        public BlogRepository(AppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Blog>> GetAllBlogPosts()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetBlogPostById(object id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public void CreateBlogPost(Blog blog)
        {
            _context.Blogs.Add(blog);
        }

        public void UpdateBlogPost(Blog blog)
        {
            _context.Blogs.Attach(blog);
            _context.Entry(blog).State = EntityState.Modified;
        }

        public void DeleteBlogPost(Blog blog)
        {
            if (_context.Entry(blog).State is EntityState.Modified)
            {
                _context.Blogs.Attach(blog);
            }
            _context.Blogs.Remove(blog);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
