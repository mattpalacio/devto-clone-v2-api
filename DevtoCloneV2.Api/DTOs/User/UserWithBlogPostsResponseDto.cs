using DevtoCloneV2.Api.DTOs.Blog;

namespace DevtoCloneV2.Api.DTOs.User
{
    public class UserWithBlogPostsResponseDto : UserResponseDto
    {
        public IEnumerable<BlogResponseDto> BlogPosts { get; set; } = null!;
    }
}
