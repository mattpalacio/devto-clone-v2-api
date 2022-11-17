using DevtoCloneV2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DevtoCloneV2.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map Overrides
            MapOverrides(modelBuilder);

            // Seed User table
            SeedUsers(modelBuilder);

            // Seed Blog table
            SeedBlogPosts(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Username = "matt",
                        Email = "matt@email.com"
                    },
                    new User
                    {
                        Id = 2,
                        Username = "patrick",
                        Email = "patrick@email.com"
                    },
                    new User
                    {
                        Id = 3,
                        Username = "anne",
                        Email = "anne@email.com"
                    }
                );
        }

        private static void SeedBlogPosts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasData(
                    new Blog
                    {
                        Id = 1,
                        Title = "Blog Post #1",
                        Content = "This is the first blog post.",
                        UserId = 1
                    },
                    new Blog
                    {
                        Id = 2,
                        Title = "Blog Post #2",
                        Content = "This is the second blog post.",
                        UserId = 1
                    },
                    new Blog
                    {
                        Id = 3,
                        Title = "Blog Post #3",
                        Content = "This is the third blog post.",
                        UserId = 2
                    }
                );
        }

        private static void MapOverrides(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
               .Property(p => p.Email)
               .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Email })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Username })
                .IsUnique();

            modelBuilder.Entity<Blog>()
                .HasKey(x => x.Id);
        }
    }
}