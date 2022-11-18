using DevtoCloneV2.Api.DTOs.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DevtoCloneV2.Api.DTOs.Blog
{
    public class BlogResponseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [JsonPropertyName("authorId")]
        public int UserId { get; set; }
        public UserResponseDto User { get; set; } = null!;
        public string Author { get; set; }
    }
}
