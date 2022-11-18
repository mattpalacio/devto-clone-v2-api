namespace DevtoCloneV2.Api.DTOs.Blog
{
    public class CreateBlogRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
    }
}
