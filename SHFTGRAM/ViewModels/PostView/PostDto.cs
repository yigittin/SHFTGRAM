namespace SHFTGRAM.ViewModels.PostView
{
    public class PostDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int LikeCount { get; set; }
        public string? UserName { get; set; }
    }
}
