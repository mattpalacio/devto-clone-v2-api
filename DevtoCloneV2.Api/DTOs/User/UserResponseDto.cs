namespace DevtoCloneV2.Api.DTOs.User
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
